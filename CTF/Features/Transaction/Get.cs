using MediatR;

namespace CTF.Features.Transaction;

public record Get : IRequest<IQueryable<Transaction>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? ParentTransactionId { get; set; }
    public Guid? GeneratedBySessionId { get; set; }
    public Guid? ProcessedBySessionId { get; set; }
}
