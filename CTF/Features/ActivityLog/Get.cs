using MediatR;

namespace CTF.Features.ActivityLog;

public record Get : IRequest<IQueryable<Models.ActivityLog>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool? NoTracking { get; set; }
}
