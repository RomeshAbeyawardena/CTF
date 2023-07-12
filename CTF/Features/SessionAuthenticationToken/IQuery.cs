using RST.Contracts;

namespace CTF.Features.SessionAuthenticationToken;

public interface IQuery : IDateRangeQuery
{
    Guid? SessionId { get; set; }
}
