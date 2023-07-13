namespace CTF.Models;

public interface IResource
{
    Guid? ClientId { get; set; }
    string? Name { get; set; }
    string? Description { get; set; }
    bool IsAvailable { get; set; }
    DateTimeOffset? ImportedDate { get; set; }
}
