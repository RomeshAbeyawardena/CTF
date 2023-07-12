using AutoMapper;
using RST.Mediatr.Extensions;

namespace CTF.Features.SessionAuthenticationToken;

public class SaveHandler : RepositoryHandlerBase<SaveCommand
    , Models.SessionAuthenticationToken, Models.SessionAuthenticationToken>
{
    protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.SessionAuthenticationToken> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.SessionAuthenticationToken>, cancellationToken);
    }
}
