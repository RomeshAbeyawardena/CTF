using RST.Mediatr.Extensions;

namespace CTF.Features.ActivityLog;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.ActivityLog>, Models.ActivityLog>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.ActivityLog>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
        }

        if (request.ClientId.HasValue)
        {
            query.And(s => s.ClientId == request.ClientId);
        }

        if (request.SessionId.HasValue)
        {
            query.And(s => s.SessionId == request.SessionId);
        }

        if (request.TransactionId.HasValue)
        {
            query.And(s => s.TransactionId == request.TransactionId);
        }

        if (request.TransactionDefinitionId.HasValue)
        {
            query.And(s => s.TransactionDefinitionId == request.TransactionDefinitionId);
        }

        if (request.TransactionTypeId.HasValue)
        {
            query.And(s => s.TransactionTypeId == request.TransactionTypeId);
        }

        if (request.ActivityType.HasValue)
        {
            var enumValue = Enum.GetName(typeof(Enumerations.ActivityType), request.ActivityType);
            if(!string.IsNullOrWhiteSpace(enumValue))
            {
                query.And(s => s.ActivityType!.Name == enumValue);
            }
        }

        if (request.ActivityTypeId.HasValue)
        {
            query.And(s => s.ActivityTypeId == request.ActivityTypeId);
        }

        return Repository!.Where(query);
    }
}
