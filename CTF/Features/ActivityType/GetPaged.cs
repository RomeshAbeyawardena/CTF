using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.ActivityType;

public record GetPaged : IPagedRequest<Models.ActivityType>, IQuery
{
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public string? NameSearch { get; set; }
    public Enumerations.ActivityType? ActivityType { get; set; }
}
