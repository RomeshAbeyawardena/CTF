using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.ActivityLog;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPaged, Models.ActivityLog>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    protected override Expression<Func<Models.ActivityLog, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return q => (!query.StartDate.HasValue) || q.Created >= query.StartDate
            && (!query.EndDate.HasValue) || q.Created <= query.EndDate;
    }

    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<Models.ActivityLog>> Handle(GetPaged request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<Get>(request), cancellationToken);

        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
