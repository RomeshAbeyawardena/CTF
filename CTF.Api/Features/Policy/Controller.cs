﻿using AutoMapper;
using CTF.Features.Policy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.Policy;

[ApiController, Route(API_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    public const string API_URL = $"{Api.CURRENT_API_BASE_URL}/Policy";
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, Route("{id?}")] public async Task<IPagedResult<Models.Policy>> GetPolicys(
        [FromQuery]GetPagedQuery query, CancellationToken cancellationToken,
        [FromRoute]Guid? id)
    {
        query.Id = id;
        return Mapper!.Map<IPagedResult<Models.Policy>>(
            await Mediator!.Send(query, cancellationToken));
    }

    [HttpPost] public async Task<Models.Policy> SavePolicy(
        [FromForm]SaveCommand command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<Models.Policy>(await Mediator!.Send(command, cancellationToken));
    }

    [HttpPut, Route("{id?}")]
    public Task<Models.Policy> SavePolicy(
        [FromForm] SaveCommand command, CancellationToken cancellationToken,
        [FromRoute]Guid? id)
    {
        command.Id = id;
        return SavePolicy(command, cancellationToken);
    }
}
