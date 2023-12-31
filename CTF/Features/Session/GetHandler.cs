﻿using RST.Mediatr.Extensions;
using System.Data.Entity;

namespace CTF.Features.Session;

public class GetHandler : RepositoryHandlerBase<Get, IQueryable<Models.Session>, Models.Session>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Session>> Handle(Get request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
        }

        if (!string.IsNullOrWhiteSpace(request.Key))
        {
            query.And(s => s.Key == request.Key);
        }

        if (!string.IsNullOrWhiteSpace(request.Subject))
        {
            query.And(s => s.Subject == request.Subject);
        }

        if (!string.IsNullOrWhiteSpace(request.Token))
        {
            query.And(s => s.Token == request.Token);
        }

        return Repository!.Where(query).Include(s => s.SessionResourceAccess).Include(s => s.OwnerTransaction);
    }
}
