using MediatR;

namespace CTF.Features.Authentication;

public record VerifyResourceAccessQuery : IRequest<ResourceAccessVerificationResponse>
{
    public string? AuthenticationToken { get; set; }
    public string? ResourceName { get; set; }
}
