using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.Session;

public class SaveCommand : IRequest<Models.Session>, ISession, IDbCommand
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public bool CommitChanges { get; set; }
    public Guid? OwnerTransactionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
