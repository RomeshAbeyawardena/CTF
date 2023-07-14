using CTF.Models;

namespace CTF.Features.Initalisation;

public record InitialisationResult : IInitialisationResult
{
    public InitialisationResult()
    {
        ExistingResources = new List<IResource>();
        NewResources = new List<IResource>();
    }

    public IEnumerable<IResource> ExistingResources { get; set; }
    public IEnumerable<IResource> NewResources { get; set; }
}
