using RST.Contracts;

namespace CTF.Features.Resource;

public interface IQuery : IDateRangeQuery
{
    Guid? ClientId { get; set; }
    string? NameSearch { get; set; }
    bool? ShowAll { get; set; }
}
