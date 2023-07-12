using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using RST.Contracts;
using RST.Mediatr.Extensions;

namespace CTF.Features.Policy;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPagedQuery, Models.Policy>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<Models.Policy>> Handle(GetPagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<GetQuery>(request), cancellationToken);
        
        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
