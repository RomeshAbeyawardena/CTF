using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.Client;

public record GetPagedQuery : IPagedRequest<Models.Client>, IQuery
{
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    public Guid? ParentClientId { get; set; }
    public string? NameSearch { get; set; }
}
