using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionDefinition;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.TransactionDefinition, Models.TransactionDefinition>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.TransactionDefinition> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.TransactionDefinition>, cancellationToken);
    }
}
