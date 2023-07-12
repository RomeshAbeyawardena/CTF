using CTF.Models;

namespace CTF.Features.Authentication;

public record ValidationSessionResponse : IValidationSessionResponse
{
    public bool Success { get; set; }
    public string? Reason { get; set; }
    public string? AuthenticationToken { get; set; }
    public DateTimeOffset? TokenExpiry { get; set; }
}
