using CTF.Models;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(SessionAuthenticationToken))]
public record SessionAuthenticationToken : ISessionAuthenticationToken
{
    [Key]
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? Value { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public DateTimeOffset Created { get; set; }

    public virtual Models.Session? Session { get; set; }
}
