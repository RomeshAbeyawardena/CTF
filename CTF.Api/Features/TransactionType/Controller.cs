﻿using AutoMapper;
using CTF.Features.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.TransactionType;

[ApiController]
public class Controller : EnableInjectionBase<InjectAttribute>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, Route("{id?}")]
    public async Task<IPagedResult<TransactionType>> GetTransactionTypes(
        [FromQuery] GetPaged query, CancellationToken cancellationToken,
        [FromRoute] Guid? id)
    {
        query.Id = id;
        return Mapper!.Map<IPagedResult<TransactionType>>(
            await Mediator!.Send(query, cancellationToken));
    }

    [HttpPost]
    public async Task<TransactionType> SaveTransactionType(
        [FromForm] SaveCommand command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<TransactionType>(await Mediator!.Send(command, cancellationToken));
    }

    [HttpPut, Route("{id?}")]
    public Task<TransactionType> SaveTransactionType(
        [FromForm] SaveCommand command, CancellationToken cancellationToken,
        [FromRoute] Guid? id)
    {
        command.Id = id;
        return SaveTransactionType(command, cancellationToken);
    }
}