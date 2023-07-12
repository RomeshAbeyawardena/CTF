using CTF.Models;

namespace CTF.Api.Features.Models;

public record Resource : IResource
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ImportedDate { get; set; }
}
