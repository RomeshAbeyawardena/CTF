namespace CTF.Models;

/// <summary>
/// Represents a transaction
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Gets or sets the transaction type ID
    /// </summary>
    Guid TransactionTypeId { get; set; }
    /// <summary>
    /// Gets or sets the transaction definition ID
    /// </summary>
    Guid TransactionDefinitionId { get; set; }
    /// <summary>
    /// Gets or sets the parent transaction ID
    /// </summary>
    Guid? ParentTransactionId { get; set; }
    /// <summary>
    /// Gets or sets the session ID used to generate the transaction
    /// </summary>
    Guid GeneratedBySessionId { get; set; }
    /// <summary>
    /// Gets or sets the session ID used to verify the transaction
    /// </summary>
    Guid? ProcessedBySessionId { get; set; }
    /// <summary>
    /// Gets or sets the payload
    /// </summary>
    string? Payload { get; set; }
    /// <summary>
    /// Gets or sets the hash
    /// </summary>
    string? Hash { get; set; }
    /// <summary>
    /// Gets or sets the valid from timestamp
    /// </summary>
    DateTimeOffset? ValidFrom { get; set; }
    /// <summary>
    /// Gets or sets the processed timestamp
    /// </summary>
    DateTimeOffset? ProcessedTimestamp { get; set; }

}
