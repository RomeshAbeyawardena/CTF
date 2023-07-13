using Microsoft.AspNetCore.Mvc;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;
using System.Data;
using Dapper;
namespace CTF.Api.Features.Initalisation;

[ApiController]
public class Controller : EnableInjectionBase<InjectAttribute>
{
    [Inject] protected IDbConnection? Connection { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpPost] 
    public async Task<InitialisationResult> Initialise(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Connection!.Open();
        var resources = await Connection.QueryAsync<Models.Resource>("SELECT ");
        return new InitialisationResult();
    }
}
