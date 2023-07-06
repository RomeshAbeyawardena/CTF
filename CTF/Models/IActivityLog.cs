using RST.Contracts;

namespace CTF.Models;

public interface IActivityLog : ICreated
{
    Guid SessionId { get; set; }
    Guid ActivityTypeId { get; set; }
    Guid? TransactionId { get; set; }
    Guid? TransactionDefinitionId { get; set; }
    Guid? TransactionTypeId { get; set; }
}
