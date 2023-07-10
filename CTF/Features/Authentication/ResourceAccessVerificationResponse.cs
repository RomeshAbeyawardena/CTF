namespace CTF.Features.Authentication;

public record ResourceAccessVerificationResponse
{
    public bool Success { get; set; }
    public string? Claims { get; set; }
}
