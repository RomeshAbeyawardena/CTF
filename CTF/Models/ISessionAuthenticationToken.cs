using RST.Contracts;

namespace CTF.Models;

public interface ISessionAuthenticationToken : ICreated
{
    Guid SessionId { get; set; }
    string? Value { get; set; }
    DateTimeOffset? ValidTo { get; set; }
}
