using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(ActivityType))]
public record ActivityType : IActivityType, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
