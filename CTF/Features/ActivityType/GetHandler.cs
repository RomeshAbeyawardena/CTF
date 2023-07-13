﻿using Microsoft.EntityFrameworkCore;
using RST.Mediatr.Extensions;

namespace CTF.Features.ActivityType;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.ActivityType>, Models.ActivityType>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.ActivityType>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
        }

        if (!string.IsNullOrWhiteSpace(request.NameSearch))
        {
            query.And(s => EF.Functions.Like(s.Name!, $"%{request.NameSearch}%"));
        }

        return Repository!.Where(query);
    }
}
