using AutoMapper;
using CTF.Models;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using ActivityLogFeature = CTF.Features.ActivityLog;
namespace CTF.Features.Session;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Session, Models.Session>
{
    [Inject] protected IApplicationSettings? applicationSettings;
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async override Task<Models.Session> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        var activityType = request.Id.HasValue
                    ? Enumerations.ActivityType.Insert
                    : Enumerations.ActivityType.Update;

        var logActivity = applicationSettings?.LogActivity ?? false; ;
        request.CommitChanges = !logActivity;
        var savedSession = await ProcessSave(request, Mapper!.Map<Models.Session>, cancellationToken);

        if (logActivity)
        {
            await Mediator!.Send(new ActivityLogFeature.SaveCommand
            {
                ActivityType = activityType,
                SessionId = savedSession.Id,
                CommitChanges = true
            }, cancellationToken);
        }

        return savedSession;
    }
}
