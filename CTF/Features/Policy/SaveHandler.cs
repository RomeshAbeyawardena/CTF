using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.Policy;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Policy, Models.Policy>
{
    [Inject] protected IMapper? Mapper {  get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.Policy> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.Policy>, cancellationToken);
    }
}
