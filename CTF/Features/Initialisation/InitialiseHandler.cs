using Azure.Core;
using CTF.Features.Initalisation;
using CTF.Models;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RST.Contracts;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;
using System.Data;
using System.Text;

namespace CTF.Features.Initialisation;

public class InitialiseHandler : EnableInjectionBase<InjectAttribute>, IRequestHandler<InitialiseCommand, InitialisationResult>
{
    [Inject] IClockProvider? ClockProvider { get; set; }
    [Inject] IMediator? Mediator { get; set; }
    [Inject] IDbConnection? Connection { get; set; }

    internal static IEnumerable<string> GetNamespaces(IEnumerable<string>? excludedNamespaces)
    {
        var defaultExcludedNamespaces = new[] { "Models" };

        if (excludedNamespaces != null && excludedNamespaces.Any())
        {
            defaultExcludedNamespaces = defaultExcludedNamespaces.Union(excludedNamespaces).ToArray();
        }

        return typeof(Instance).Assembly.GetTypes().Where(a => !string.IsNullOrWhiteSpace(a.Namespace)
                && a.Namespace.StartsWith("CTF.Features") && !defaultExcludedNamespaces.Any(e => a.Namespace.EndsWith(e)))
                .Select(a =>
                {
                    var n = a.Namespace!.Split('.');
                    return n[^1];
                }).OrderBy(a => a).Distinct();
    }

    internal static IEnumerable<IResource> GetExcludedResources(IEnumerable<IResource> resources, IEnumerable<string>? excludedResources)
    {
        var defaultExcludedResources = resources;
        if (excludedResources != null)
        {
            defaultExcludedResources = defaultExcludedResources
                .Union(excludedResources
                    .Select(a => new Models.Resource
                    {
                        Name = a
                    })).ToArray();
        }

        return defaultExcludedResources;
    }

    public InitialiseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    public async Task<InitialisationResult> Handle(InitialiseCommand request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(new Resource.GetQuery(), cancellationToken);
        var resources = await query.ToArrayAsync(cancellationToken);

        var namespaces = GetNamespaces(request.ExcludedNamespaces);

        var sqlBuilder = new StringBuilder("INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES");

        bool isFirst = true;
        var importDate = ClockProvider!.UtcNow;

        var excludedResources = GetExcludedResources(resources, request.ExcludedResources);

        foreach (var @namespace in namespaces)
        {
            if (excludedResources.All(r => r.Name != @namespace))
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sqlBuilder.Append(',');
                }

                sqlBuilder.AppendLine($"(NEWID(), '{@namespace}', '{@namespace} (Imported on {importDate})', 1, GETUTCDATE())");
            }
        }

        if (request.CommitChanges)
        {
            await Connection.ExecuteAsync(sqlBuilder.ToString());
        }

        query = await Mediator.Send(new Resource.GetQuery { 
            ImportedDate = importDate
        }, cancellationToken);

        return new InitialisationResult {
            ExistingResources = resources,
            NewResources = await query.ToArrayAsync(cancellationToken)
        };
    }
}
