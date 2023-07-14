using RST.Contracts;

namespace CTF.Features.Transaction;

public interface IQuery : IDateRangeQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    Guid? ClientId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid? SessionId { get; set; }
}
