using MediatR;

namespace CTF.Features.Policy;

public record GetQuery : IRequest<IQueryable<Models.Policy>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; }
    public bool? HasPublicAccess { get; set; }
    public bool? CanRead { get; set; }
    public bool? CanWrite { get; set; }
    public bool? CanDelete { get; set; }
}
