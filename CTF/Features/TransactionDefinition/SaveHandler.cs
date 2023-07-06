using AutoMapper;
using CTF.Models;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using ActivityLogFeature = CTF.Features.ActivityLog;
namespace CTF.Features.TransactionDefinition;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.TransactionDefinition, Models.TransactionDefinition>
{
    [Inject] protected IApplicationSettings? ApplicationSettings;
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.TransactionDefinition> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        var logActivity = ApplicationSettings?.LogActivity ?? false; ;
        request.CommitChanges = !logActivity;
        var savedTransactionDefinition = await ProcessSave(request, Mapper!.Map<Models.TransactionDefinition>, cancellationToken);
        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                SessionId = request.SessionId,
                TransactionDefinitionId = savedTransactionDefinition.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedTransactionDefinition;
    }
}
