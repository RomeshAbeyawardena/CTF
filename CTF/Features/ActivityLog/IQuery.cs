using RST.Contracts;

namespace CTF.Features.ActivityLog;

public interface IQuery : IDateRangeQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    Guid? SessionId { get; set; }
    Guid? TransactionId { get; set; }
    Guid? TransactionDefinitionId { get; set; }
    Guid? TransactionTypeId { get; set; }
}
