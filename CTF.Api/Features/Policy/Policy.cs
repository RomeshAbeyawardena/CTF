namespace CTF.Api.Features.Policy;

public record Policy : Models.IPolicy
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public bool HasPublicAccess { get; set; }
    public bool CanRead { get; set; }
    public bool CanWrite { get; set; }
    public bool CanDelete { get; set; }
}
