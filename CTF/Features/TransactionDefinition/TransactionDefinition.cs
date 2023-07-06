using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(TransactionDefinition))]
public record TransactionDefinition : ITransactionDefinition, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 255)]
    public string? Key { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 800)]
    public string? Token { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 255)]
    public string? Subject { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, int.MaxValue)]
    public string? Payload { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
