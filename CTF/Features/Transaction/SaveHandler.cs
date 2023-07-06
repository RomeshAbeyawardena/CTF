using AutoMapper;
using CTF.Models;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using ActivityLogFeature = CTF.Features.ActivityLog;

namespace CTF.Features.Transaction;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Transaction, Models.Transaction>
{
    [Inject] protected IApplicationSettings? ApplicationSettings;
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.Transaction> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        var activityType = request.Id.HasValue
                    ? Enumerations.ActivityType.Insert
                    : Enumerations.ActivityType.Update;

        var logActivity = ApplicationSettings?.LogActivity ?? false; ;
        request.CommitChanges = !logActivity;
        var savedTransaction = await ProcessSave(request, Mapper!.Map<Models.Transaction>, cancellationToken);

        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                ActivityType = activityType,
                SessionId = request.ProcessedBySessionId.GetValueOrDefault(request.GeneratedBySessionId),
                TransactionId = savedTransaction.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedTransaction;
    }
}
