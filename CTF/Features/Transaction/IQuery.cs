namespace CTF.Features.Transaction;

public interface IQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid? GeneratedBySessionId { get; set; }
    public Guid? ProcessedBySessionId { get; set; }
}
