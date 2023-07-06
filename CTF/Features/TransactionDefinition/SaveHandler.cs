using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionDefinition;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, TransactionDefinition, TransactionDefinition>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<TransactionDefinition> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<TransactionDefinition>, cancellationToken);
    }
}
