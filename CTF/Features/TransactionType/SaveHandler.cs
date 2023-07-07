using AutoMapper;
using CTF.Models;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using ActivityLogFeature = CTF.Features.ActivityLog;
namespace CTF.Features.TransactionType;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.TransactionType, Models.TransactionType>
{
    [Inject] protected IApplicationSettings? ApplicationSettings;
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.TransactionType> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        var activityType = request.Id.HasValue
                    ? Enumerations.ActivityType.Insert
                    : Enumerations.ActivityType.Update;

        var logActivity = ApplicationSettings?.LogActivity ?? false;
        request.CommitChanges = !logActivity;
        var savedTransactionType = await ProcessSave(request, Mapper!.Map<Models.TransactionType>, cancellationToken);

        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                Type = activityType,
                SessionId = request.SessionId,
                TransactionTypeId = savedTransactionType.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedTransactionType;
    }
}
