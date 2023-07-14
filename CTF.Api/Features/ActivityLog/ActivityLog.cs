using CTF.Models;

namespace CTF.Api.Features.Models;

public record ActivityLog : IActivityLog
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public Guid SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid ActivityTypeId { get; set; }
    public Guid? AuditedActivityTypeId { get; set; }
}
