using RST.Mediatr.Extensions;

namespace CTF.Features.Transaction;

public class GetHandler : RepositoryHandlerBase<Get, IQueryable<Models.Transaction>, Models.Transaction>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Transaction>> Handle(Get request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
        }

        if (request.TransactionDefinitionId.HasValue)
        {
            query.And(s => s.TransactionDefinitionId == request.TransactionDefinitionId);
        }

        if (request.TransactionTypeId.HasValue)
        {
            query.And(s => s.TransactionTypeId == request.TransactionTypeId);
        }

        if (request.ParentTransactionId.HasValue)
        {
            query.And(s => s.ParentTransactionId == request.ParentTransactionId);
        }

        if (request.SessionId.HasValue)
        {
            query.And(s => s.GeneratedBySessionId == request.SessionId 
                || (!s.ProcessedBySessionId.HasValue || s.ProcessedBySessionId == request.SessionId));
        }

        return Repository!.Where(query);
    }
}
