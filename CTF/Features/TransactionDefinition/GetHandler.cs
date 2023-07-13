using Microsoft.AspNetCore.Http.Extensions;
using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionDefinition;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.TransactionDefinition>, Models.TransactionDefinition>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.TransactionDefinition>> Handle(GetQuery request, CancellationToken cancellationToken)
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

        if (!string.IsNullOrWhiteSpace(request.Key))
        {
            query.And(s => s.Key == request.Key);
        }

        if (!string.IsNullOrWhiteSpace(request.Token))
        {
            query.And(s => s.Token == request.Token);
        }

        if (!string.IsNullOrWhiteSpace(request.Subject))
        {
            query.And(s => s.Subject == request.Subject);
        }

        return Repository!.Where(query);
    }
}
