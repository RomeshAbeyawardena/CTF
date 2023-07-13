namespace CTF.Features.Initalisation;

public record InitialisationResult
{
    public InitialisationResult()
    {
        ExistingFeatures = new List<string>();
        NewFeatures = new List<string>();
    }

    public IEnumerable<string> ExistingFeatures { get; set; }
    public IEnumerable<string> NewFeatures { get; set; }
}
