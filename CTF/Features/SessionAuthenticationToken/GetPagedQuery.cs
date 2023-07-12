
using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.SessionAuthenticationToken;

public record GetPagedQuery : IPagedRequest<Models.SessionAuthenticationToken>
{
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
}
