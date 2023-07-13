using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.Session;

public record GetPagedQuery : IPagedRequest<Models.Session>, IQuery
{
    public Guid? OwnerTransactionId { get; set; }
    public Guid? ClientId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public Guid? Id { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}
