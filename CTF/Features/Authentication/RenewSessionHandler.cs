using AutoMapper;
using MediatR;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Features.Authentication;

public class RenewSessionHandler 
    : EnableInjectionBase<InjectAttribute>, IRequestHandler<RenewSessionCommand, RenewSessionResponse>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }
    public RenewSessionHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    public async Task<RenewSessionResponse> Handle(RenewSessionCommand request, CancellationToken cancellationToken)
    {
        await Mediator!.Send(Mapper!.Map<SessionAuthenticationToken.SaveCommand>(request), cancellationToken);

        return new RenewSessionResponse();
    }
}
