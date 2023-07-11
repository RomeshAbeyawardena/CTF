using MediatR;

namespace CTF.Features.Authentication;

public record ValidateSessionQuery : IRequest<ValidationSessionResponse>
{
    public string? SessionToken { get; set; }
    public string? SessionKey { get; set; }
    public string? Claims { get; set; }
}
