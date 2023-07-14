using Microsoft.EntityFrameworkCore;
using RST.Contracts;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.Resource;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.Resource>, Models.Resource>
{
    internal static Expression<Func<Models.Resource, bool>> SetDateRangeQuery(IDateRangeQuery query)
    {
        return r => !query.StartDate.HasValue || !r.ImportedDate.HasValue
            || r.ImportedDate >= query.StartDate.Value 
            && (!query.EndDate.HasValue || !r.ImportedDate.HasValue
            || r.ImportedDate <= query.EndDate.Value);
    }

    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override Expression<Func<Models.Resource, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return SetDateRangeQuery(query);
    }

    public override async Task<IQueryable<Models.Resource>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var queryBuilder = Repository!.QueryBuilder;

        if (request.FilterByDate)
        {
            queryBuilder.And(DefineDateRangeQuery(request));
        }

        if(request.ImportedDate.HasValue)
        {
            queryBuilder.And(r => r.ImportedDate == request.ImportedDate);
        }

        if (request.Id.HasValue)
        {
            queryBuilder.And(r => r.Id == request.Id);
        }

        if (request.ClientId.HasValue)
        {
            queryBuilder.And(s => s.ClientId == request.ClientId);
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
