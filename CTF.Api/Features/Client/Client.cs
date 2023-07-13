using CTF.Models;

namespace CTF.Api.Features.Models;

public record Client : IClient
{
    public Guid? Id { get; set; }
    public Guid? ParentClientId { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
}
