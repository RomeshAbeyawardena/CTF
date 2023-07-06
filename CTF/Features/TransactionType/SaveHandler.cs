using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionType;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.TransactionType, Models.TransactionType>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.TransactionType> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.TransactionType>, cancellationToken);
    }
}
