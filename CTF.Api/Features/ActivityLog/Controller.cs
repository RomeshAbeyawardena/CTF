using AutoMapper;
using CTF.Features.ActivityLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.ActivityLog;

[ApiController, Route(API_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    public const string API_URL = $"{Api.CURRENT_API_BASE_URL}/Activity";
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, Route("{sessionId}/{id?}")] public async Task<IPagedResult<ActivityLog>> GetSessions([FromRoute]Guid sessionId,
        [FromQuery]GetPaged query, CancellationToken cancellationToken,
        [FromRoute]Guid? id)
    {
        query.SessionId = sessionId;
        query.Id = id;
        return Mapper!.Map<IPagedResult<ActivityLog>>(
            await Mediator!.Send(query, cancellationToken));
    }

    [HttpPost] public async Task<ActivityLog> SaveSession(
        [FromForm]SaveCommand command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<ActivityLog>(await Mediator!.Send(command, cancellationToken));
    }

    [HttpPut, Route("{id?}")]
    public Task<ActivityLog> SaveSession(
        [FromForm] SaveCommand command, CancellationToken cancellationToken,
        [FromRoute]Guid? id)
    {
        command.Id = id;
        return SaveSession(command, cancellationToken);
    }
}
