namespace CTF.Api.Features.Resource;

public record Resource : Models.IResource
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ImportedDate { get; set; }
}
