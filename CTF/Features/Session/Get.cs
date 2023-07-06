using MediatR;

namespace CTF.Features.Session;

public record Get : IRequest<IQueryable<Session>>, IQuery
{
    public Guid? OwnerTransactionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public Guid? Id { get; set; }
}
