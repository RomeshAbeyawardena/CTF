namespace CTF.Features.Authentication;

public record ValidationSessionResponse
{
    public bool Success { get; set; }
    public string? Reason { get; set; }
    public string? AuthenticationToken { get; set; }
    public DateTimeOffset? TokenExpiry { get; set; }
}
