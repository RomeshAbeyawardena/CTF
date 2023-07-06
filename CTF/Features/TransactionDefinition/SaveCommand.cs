using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.TransactionDefinition;

public class SaveCommand : IRequest<Models.TransactionDefinition>, ITransactionDefinition, IDbCommand
{
    public Guid? Id { get; set; }
    public bool CommitChanges { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public string? Payload { get; set; }
    public Guid SessionId { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
