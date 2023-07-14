using MediatR;

namespace CTF.Features.Authentication;

public record RenewSessionCommand : IRequest<RenewSessionResponse>
{
    public DateTimeOffset? RenewalDate { get; set; }
    public string? SessionToken { get; set; }
    public string? SessionKey { get; set; }
    public string? Claims { get; set; }
}
