using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionDefinition;

public class GetPagedHandler : PagedRepositoryHandlerBase<GetPaged, TransactionDefinition>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public GetPagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<TransactionDefinition>> Handle(GetPaged request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<Get>(request), cancellationToken);

        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
