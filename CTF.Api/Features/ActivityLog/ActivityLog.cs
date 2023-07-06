namespace CTF.Api.Features.ActivityLog;

public record ActivityLog : Models.IActivityLog
{
    public Guid? Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid ActivityTypeId { get; set; }
}
