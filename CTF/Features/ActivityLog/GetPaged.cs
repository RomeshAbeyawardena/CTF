using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.ActivityLog;

public record GetPaged : IPagedRequest<Models.ActivityLog>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool? NoTracking { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public Enumerations.ActivityType? ActivityType { get; set; }
    public Guid? ActivityTypeId { get; set; }
}
