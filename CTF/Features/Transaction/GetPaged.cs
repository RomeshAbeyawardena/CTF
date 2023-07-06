using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.Transaction;

public record GetPaged : IPagedRequest<Models.Transaction>, IQuery
{
    public bool? NoTracking { get; set; }
    public Guid? Id { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public Guid? SessionId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}
