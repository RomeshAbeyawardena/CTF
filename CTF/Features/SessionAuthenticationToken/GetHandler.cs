using RST.Contracts;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.SessionAuthenticationToken;

public class GetHandler
    : RepositoryHandlerBase<GetQuery, IQueryable<Models.SessionAuthenticationToken>, Models.SessionAuthenticationToken>
{
    internal static Expression<Func<Models.SessionAuthenticationToken, bool>> SetDateRangeQuery(IDateRangeQuery query)
    {
        return s => (!query.StartDate.HasValue || s.Created >= query.StartDate.Value)
            && (!query.EndDate.HasValue || !s.ValidTo.HasValue || s.ValidTo <= query.EndDate);
    }

    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override Expression<Func<Models.SessionAuthenticationToken, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return SetDateRangeQuery(query);
    }

    public override async Task<IQueryable<Models.SessionAuthenticationToken>> Handle(
        GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var queryBuilder = Repository!.QueryBuilder;
        
        if(request.Id.HasValue)
        {
            queryBuilder.And(s => s.Id == request.Id);
        }

        if (request.SessionId.HasValue)
        {
            queryBuilder.And(s => s.SessionId == request.SessionId);
        }

        Expression<Func<Models.SessionAuthenticationToken, bool>> 
            query = request.ProcessDateRange 
            ? request.FilterByDateRange(queryBuilder, DefineDateRangeQuery)
            : queryBuilder;

        return Repository!.Where(query);
    }
}
