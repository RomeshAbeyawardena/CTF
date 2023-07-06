using CTF.Models;
using RST.Contracts;

namespace CTF.Features.Session;

public record Session : ISession, IIdentity
{
    public Guid? OwnerTransactionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public Guid Id { get; set; }
}
