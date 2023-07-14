namespace CTF.Models;

public interface IInitialisationResult
{
    IEnumerable<IResource> ExistingResources { get; set; }
    IEnumerable<IResource> NewResources { get; set; }
}
