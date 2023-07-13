using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.ActivityLog;

public class SaveCommand : IRequest<Models.ActivityLog>, IActivityLog, IDbCommand
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public bool CommitChanges { get; set; }
    public Guid SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid ActivityTypeId { get; set; }
    public Guid? AuditedActivityTypeId { get;set; }
    public Enumerations.ActivityType? Type { get; set; }

    public Models.ActivityType? ActivityType { get; set; }
    public Models.ActivityType? AuditedActivityType { get; set; }
    public Models.Transaction? Transaction { get; set; }
    public Models.TransactionDefinition? TransactionDefinition { get; set; }
    public Models.TransactionType? TransactionType { get; set; }
}
