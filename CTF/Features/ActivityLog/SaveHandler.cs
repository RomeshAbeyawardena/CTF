using AutoMapper;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.ActivityLog;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.ActivityLog, Models.ActivityLog>
{
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.ActivityLog> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        if (request.Type.HasValue)
        {
            var activityTypes = await Mediator!.Send(new ActivityType.Get { 
                ActivityType = request.Type.Value
            }, cancellationToken);

            if (activityTypes.Any())
            {
                request.ActivityTypeId = activityTypes.FirstOrDefault()?.Id 
                    ?? throw new NullReferenceException("Activity Type not found");
            }
        }

        return await ProcessSave(request, Mapper!.Map<Models.ActivityLog>, cancellationToken);
    }
}
