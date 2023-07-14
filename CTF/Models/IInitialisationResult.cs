namespace CTF.Models;

public interface IInitialisationResult
{
    IEnumerable<string> ExistingFeatures { get; set; }
    IEnumerable<string> NewFeatures { get; set; }
}
