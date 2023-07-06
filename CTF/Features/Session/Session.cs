using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Session))]
public record Session : ISession, IIdentity
{
    public Guid? OwnerTransactionId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 255)]
    public string? Key { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 800)]
    public string? Token { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 255)]
    public string? Subject { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    [Key]public Guid Id { get; set; }
}
