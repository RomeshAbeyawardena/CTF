﻿using AutoMapper;
using CTF.Features.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.Transaction;

[ApiController, Route(API_URL)]
public class Controller : EnableInjectionBase<InjectAttribute>
{
    public const string API_URL = $"{Api.CURRENT_API_BASE_URL}/Transaction";
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, Route("{id?}")]
    public async Task<IPagedResult<Models.Transaction>> GetTransactions(
        [FromQuery] GetPaged query, CancellationToken cancellationToken,
        [FromRoute] Guid? id)
    {
        query.Id = id;
        return Mapper!.Map<IPagedResult<Models.Transaction>>(
            await Mediator!.Send(query, cancellationToken));
    }

    [HttpPost]
    public async Task<Models.Transaction> SaveTransaction(
        [FromForm] SaveCommand command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<Models.Transaction>(await Mediator!.Send(command, cancellationToken));
    }

    [HttpPut, Route("{id?}")]
    public Task<Models.Transaction> SaveTransaction(
        [FromForm] SaveCommand command, CancellationToken cancellationToken,
        [FromRoute] Guid? id)
    {
        command.Id = id;
        return SaveTransaction(command, cancellationToken);
    }
}
