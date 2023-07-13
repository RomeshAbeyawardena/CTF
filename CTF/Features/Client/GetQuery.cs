using MediatR;

namespace CTF.Features.Client;

public record GetQuery : IRequest<IQueryable<Models.Client>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? ParentClientId { get; set; }
    public string? NameSearch { get; set; }
}
