using CTF.Models;

namespace CTF.Api.Features.Models;

public class Transaction : ITransaction
{
    public Guid? Id { get; set; }
    public Guid TransactionTypeId { get; set; }
    public Guid TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid GeneratedBySessionId { get; set; }
    public Guid? ProcessedBySessionId { get; set; }
    public string? Payload { get; set; }
    public string? Hash { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ProcessedTimestamp { get; set; }
}
