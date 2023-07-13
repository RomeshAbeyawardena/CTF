using Microsoft.EntityFrameworkCore;
using RST.Mediatr.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CTF.Features.Policy;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.Policy>, Models.Policy>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Policy>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var queryBuilder = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            queryBuilder.And(p => p.Id == request.Id);
        }

        if (request.ClientId.HasValue)
        {
            queryBuilder.And(s => s.ClientId == request.ClientId);
        }

        if (!string.IsNullOrWhiteSpace(request.NameSearch))
        {
            queryBuilder.And(p => EF.Functions.Like(p.Name!, $"%{request.NameSearch}%"));
        }

        if (request.CanDelete.GetValueOrDefault())
        {
            queryBuilder.And(p => p.CanDelete);
        }

        if (request.CanRead.GetValueOrDefault())
        {
            queryBuilder.And(p => p. CanRead);
        }

        if (request.CanWrite.GetValueOrDefault())
        {
            queryBuilder.And(p => p.CanWrite);
        }

        return Repository!.Where(queryBuilder);
    }
}
