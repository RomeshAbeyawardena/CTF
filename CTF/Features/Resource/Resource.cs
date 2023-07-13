using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Resource))]
public record Resource : IResource, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public Guid? ClientId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ImportedDate { get; set; }
    public virtual ICollection<SessionResourceAccess>? SessionResourceAccess { get; set; }
    public virtual Client? Client { get; set; }
}
