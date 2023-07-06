using AutoMapper;
using CTF.Features.ActivityLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.ActivityLog;

[ApiController]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, Route("{id?}")] public async Task<IPagedResult<ActivityLog>> GetSessions(
        [FromQuery]GetPaged query, CancellationToken cancellationToken,
        [FromRoute]Guid? id)
    {
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
