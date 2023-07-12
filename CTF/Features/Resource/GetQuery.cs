using MediatR;

namespace CTF.Features.Resource;

public record GetQuery : IRequest<IQueryable<Models.Resource>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; set; }
    public bool? ShowAll { get; set; }
}
