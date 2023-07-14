using MediatR;

namespace CTF.Features.Transaction;

public record GetQuery : IRequest<IQueryable<Models.Transaction>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid? SessionId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool? NoTracking { get; set; }
}
