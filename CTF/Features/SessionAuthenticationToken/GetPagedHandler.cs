using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.Mediatr.Extensions;
using System.Linq.Expressions;

namespace CTF.Features.SessionAuthenticationToken;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPagedQuery, Models.SessionAuthenticationToken>
{
    protected IMapper? Mapper { get; set; }
    protected IMediator? Mediator { get; set; }
    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override Expression<Func<Models.SessionAuthenticationToken, bool>> DefineDateRangeQuery(IDateRangeQuery query)
    {
        return GetHandler.SetDateRangeQuery(query);
    }

    public override async Task<IPagedResult<Models.SessionAuthenticationToken>> Handle(GetPagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(
            Mapper!.Map<GetQuery>(request), cancellationToken);

        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
