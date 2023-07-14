using CTF.Features.Initalisation;
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

    public InitialiseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    public async Task<InitialisationResult> Handle(InitialiseCommand request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(new Resource.GetQuery(), cancellationToken);
        var resources = await query.ToArrayAsync(cancellationToken);

        var namespaces = typeof(Instance).Assembly.GetTypes().Where(a => !string.IsNullOrWhiteSpace(a.Namespace)
                && a.Namespace.StartsWith("CTF.Features") && !a.Namespace.EndsWith("Models"))
                .Select(a =>
                {
                    var n = a.Namespace!.Split('.');
                    return n[^1];
                }).OrderBy(a => a).Distinct().ToArray();

        var sqlBuilder = new StringBuilder("INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES");

        bool isFirst = true;
        foreach (var @namespace in namespaces)
        {
            var excludedResources = resources;
            if (request.ExcludedFeatures != null)
            {
                excludedResources = resources
                    .Union(request.ExcludedFeatures
                        .Select(a => new Models.Resource { 
                                    Name = a })).ToArray();
            }

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

                sqlBuilder.AppendLine($"(NEWID(), '{@namespace}', '{@namespace} (Imported on {DateTimeOffset.UtcNow})', 1, GETUTCDATE())");
            }
        }

        await Connection.ExecuteAsync(sqlBuilder.ToString());

        query = await Mediator.Send(new Resource.GetQuery { 
            StartDate = ClockProvider!.UtcNow.Date,
            EndDate = ClockProvider!.UtcNow.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
        }, cancellationToken);

        return new InitialisationResult();
    }
}
