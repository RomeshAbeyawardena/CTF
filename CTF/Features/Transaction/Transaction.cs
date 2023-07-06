using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Transaction))]
public record Transaction : ITransaction, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public Guid TransactionTypeId { get; set; }
    public Guid TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid GeneratedBySessionId { get; set; }
    public Guid? ProcessedBySessionId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, int.MaxValue)]
    public string? Payload { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? Hash { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ProcessedTimestamp { get; set; }
}
