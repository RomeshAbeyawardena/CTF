namespace CTF.Features.Authentication;

public record RenewSessionResponse
{
    public Guid? SessionId { get; set; }
    public string? Token { get; set; }
    public string? SessionKey { get; set; }
}
