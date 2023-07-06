using RST.Mediatr.Extensions;

namespace CTF.Features.TransactionDefinition;

public class GetHandler : RepositoryHandlerBase<Get, IQueryable<TransactionDefinition>, TransactionDefinition>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<TransactionDefinition>> Handle(Get request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(s => s.Id == request.Id);
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
