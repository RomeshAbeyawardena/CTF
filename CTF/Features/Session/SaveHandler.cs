using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.Session;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Session, Models.Session>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.Session> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.Session>, cancellationToken);
    }
}
