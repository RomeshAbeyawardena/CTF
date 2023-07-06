using AutoMapper;
using CTF.Models;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using ActivityLogFeature = CTF.Features.ActivityLog;
namespace CTF.Features.ActivityType;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.ActivityType, Models.ActivityType>
{
    [Inject] protected IApplicationSettings? ApplicationSettings;
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.ActivityType> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        var logActivity = ApplicationSettings?.LogActivity ?? false;
        request.CommitChanges = !logActivity;
        var savedTransactionType = await ProcessSave(request, Mapper!.Map<Models.ActivityType>, cancellationToken);

        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                SessionId = request.SessionId,
                TransactionTypeId = savedTransactionType.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedTransactionType;
    }
}
