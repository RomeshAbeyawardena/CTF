using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.Resource;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPagedQuery, Models.Resource>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    
    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override Expression<Func<Models.Resource, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return GetHandler.SetDateRangeQuery(query);
    }

    public override async Task<IPagedResult<Models.Resource>> Handle(GetPagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<GetQuery>(request), cancellationToken);

        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
