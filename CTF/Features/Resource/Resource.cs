using CTF.Models;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Resource))]
public record Resource : IResource, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
}
