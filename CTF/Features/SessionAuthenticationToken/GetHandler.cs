using RST.Contracts;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.SessionAuthenticationToken;

public class GetHandler
    : RepositoryHandlerBase<GetQuery, IQueryable<Models.SessionAuthenticationToken>, Models.SessionAuthenticationToken>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override Expression<Func<Models.SessionAuthenticationToken, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return base.DefineDateRangeQuery(query);
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
