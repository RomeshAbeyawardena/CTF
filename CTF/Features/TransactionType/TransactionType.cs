using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(TransactionType))]
public record TransactionType : ITransactionType, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 80)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
