using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.TransactionType;

public record GetPaged : IPagedRequest<Models.TransactionType>, IQuery
{
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public string? NameSearch { get; set; }
}
