using CTF.Models;
using RST.Attributes;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Client))]
public record Client : IClient, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public Guid? ParentClientId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 80)]
    public string? Reference { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? DisplayName { get; set; }

    public virtual Client? ParentClient { get; set; }
}
