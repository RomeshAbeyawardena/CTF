using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.Session;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPagedQuery, Models.Session>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    protected override Expression<Func<Models.Session, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return q => (!q.ValidFrom.HasValue || !query.StartDate.HasValue) || q.ValidFrom >= query.StartDate
            && (!q.ValidTo.HasValue || !query.EndDate.HasValue) || q.ValidTo <= query.EndDate;
    }

    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<Models.Session>> Handle(GetPagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<GetQuery>(request), cancellationToken);

        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
