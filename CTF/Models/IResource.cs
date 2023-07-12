namespace CTF.Models;

public interface IResource
{
    string? Name { get; set; }
    string? Description { get; set; }
    bool IsAvailable { get; set; }
    DateTimeOffset? ImportedDate { get; set; }
}
