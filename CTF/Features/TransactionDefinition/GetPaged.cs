using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.TransactionDefinition;

public record GetPaged : IPagedRequest<TransactionDefinition>, IQuery
{
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public Guid? SessionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
}
