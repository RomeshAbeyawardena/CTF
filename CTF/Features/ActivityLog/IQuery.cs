using RST.Contracts;

namespace CTF.Features.ActivityLog;

public interface IQuery : IDateRangeQuery
{
    /// <summary>
    /// Gets or sets the Activity log ID
    /// </summary>
    Guid? Id { get; set; }
    Guid? SessionId { get; set; }
    Guid? TransactionId { get; set; }
    Guid? TransactionDefinitionId { get; set; }
    Guid? TransactionTypeId { get; set; }
    Guid? ActivityTypeId { get; set; }
    Enumerations.ActivityType? ActivityType { get; set; }
}
