using Microsoft.EntityFrameworkCore;
using RST.Mediatr.Extensions;

namespace CTF.Features.Resource;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.Resource>, Models.Resource>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Resource>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var queryBuilder = Repository!.QueryBuilder;
        
        if (request.Id.HasValue)
        {
            queryBuilder.And(r => r.Id == request.Id);
        }

        if (!request.ShowAll.HasValue || !request.ShowAll.Value)
        {
            queryBuilder.And(r => r.IsAvailable);
        }

        if (!string.IsNullOrWhiteSpace(request.NameSearch))
        {
            queryBuilder.And(r => EF.Functions.Like(r.Name!, $"%{request.NameSearch}%"));
        }

        return Repository.Where(queryBuilder).Include(s => s.SessionResourceAccess);
    }
}
