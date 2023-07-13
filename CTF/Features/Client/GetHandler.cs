using Microsoft.EntityFrameworkCore;
using RST.Mediatr.Extensions;

namespace CTF.Features.Client;

public class GetHandler : RepositoryHandlerBase<GetQuery, IQueryable<Models.Client>, Models.Client>
{
    public GetHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IQueryable<Models.Client>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var query = Repository!.QueryBuilder;

        if (request.Id.HasValue)
        {
            query.And(c => c.Id == request.Id);
        }

        if (request.ParentClientId.HasValue)
        {
            query.And(c => c.ParentClientId == request.ParentClientId);
        }

        if (!string.IsNullOrWhiteSpace(request.NameSearch))
        {
            query.And(c => EF.Functions.Like(c.Reference!, $"%{request.NameSearch}%") 
                || EF.Functions.Like(c.Name!, $"%{request.NameSearch}%"));
        }

        return Repository!.Where(query);
    }
}
