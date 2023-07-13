using RST.Contracts;

namespace CTF.Models;

public interface IActivityLog : ICreated
{
    Guid? ClientId { get; set; }
    Guid SessionId { get; set; }
    Guid ActivityTypeId { get; set; }
    Guid? TransactionId { get; set; }
    Guid? TransactionDefinitionId { get; set; }
    Guid? TransactionTypeId { get; set; }
    Guid? AuditedActivityTypeId { get; set; }
}
