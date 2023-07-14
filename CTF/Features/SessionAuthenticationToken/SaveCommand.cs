using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.SessionAuthenticationToken;

public record SaveCommand
    : IRequest<Models.SessionAuthenticationToken>,
      ISessionAuthenticationToken, IDbCommand
{
    public Guid? Id { get; set; }
    public bool CommitChanges { get; set; }
    public Guid SessionId { get; set; }
    public string? Value { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public DateTimeOffset Created { get; set; }
}
