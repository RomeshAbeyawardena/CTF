using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.Transaction;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Transaction, Models.Transaction>
{
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.Transaction> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return ProcessSave(request, Mapper!.Map<Models.Transaction>, cancellationToken);
    }
}
