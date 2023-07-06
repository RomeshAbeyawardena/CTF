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
        var activityType = request.Id.HasValue
                    ? Enumerations.ActivityType.Insert
                    : Enumerations.ActivityType.Update;

        var logActivity = ApplicationSettings?.LogActivity ?? false;
        request.CommitChanges = !logActivity;
        var savedActivityType = await ProcessSave(request, Mapper!.Map<Models.ActivityType>, cancellationToken);

        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                ActivityType = activityType,
                SessionId = request.SessionId,
                ActivityTypeId = savedActivityType.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedActivityType;
    }
}
