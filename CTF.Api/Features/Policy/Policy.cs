using CTF.Models;

namespace CTF.Api.Features.Models;

public record Policy : IPolicy
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public string? Name { get; set; }
    public bool HasPublicAccess { get; set; }
    public bool CanRead { get; set; }
    public bool CanWrite { get; set; }
    public bool CanDelete { get; set; }
}
