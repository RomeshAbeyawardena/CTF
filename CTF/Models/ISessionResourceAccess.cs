using RST.Contracts;

namespace CTF.Models;

public interface ISessionResourceAccess : ICreated
{
    Guid SessionId { get; set; }
    Guid ResourceId { get; set; }
    bool IsEnabled { get; set; }
    DateTimeOffset? ValidTo { get; set; }
}
