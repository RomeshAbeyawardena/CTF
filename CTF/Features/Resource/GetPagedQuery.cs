using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.Resource;

public record GetPagedQuery : IPagedRequest<Models.Resource>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public string? NameSearch { get; set; }
    public bool? ShowAll { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}
