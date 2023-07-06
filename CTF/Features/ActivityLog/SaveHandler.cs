using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.ActivityLog;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.ActivityLog, Models.ActivityLog>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.ActivityLog> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.ActivityLog>, cancellationToken);
    }
}
