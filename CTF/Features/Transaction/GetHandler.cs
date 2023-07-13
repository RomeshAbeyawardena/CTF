using Microsoft.AspNetCore.Http.Extensions;
using RST.Mediatr.Extensions;

namespace CTF.Features.Transaction;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.Transaction>, Models.Transaction>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Transaction>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
        }

        if (request.ClientId.HasValue)
        {
            query.And(s => s.ClientId == request.ClientId);
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
