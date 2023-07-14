using RST.Contracts;

namespace CTF.Features.Resource;

public interface IQuery : IDateRangeQuery
{
    DateTimeOffset? ImportedDate { get; set; }
    Guid? ClientId { get; set; }
    string? NameSearch { get; set; }
    bool? ShowAll { get; set; }
}
