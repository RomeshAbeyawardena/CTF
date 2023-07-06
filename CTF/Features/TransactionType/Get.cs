﻿using MediatR;

namespace CTF.Features.TransactionType;

public record Get : IRequest<IQueryable<TransactionType>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; set; }
}
