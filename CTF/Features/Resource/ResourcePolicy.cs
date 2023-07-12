using CTF.Models;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(ResourcePolicy))]
public record ResourcePolicy : IResourcePolicy
{
    [Key]
    public Guid? Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid PolicyId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public DateTimeOffset Created { get; set; }

    public virtual Resource? Resource { get; set; }
    public virtual Policy? Policy { get; set; } 
}
