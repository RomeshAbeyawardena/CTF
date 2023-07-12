namespace CTF.Models;

public interface IValidationSessionResponse
{
    bool Success { get; set; }
    string? Reason { get; set; }
    string? AuthenticationToken { get; set; }
    DateTimeOffset? TokenExpiry { get; set; }
}
