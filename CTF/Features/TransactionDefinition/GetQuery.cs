using MediatR;

namespace CTF.Features.TransactionDefinition;

public record GetQuery : IRequest<IQueryable<Models.TransactionDefinition>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
}
