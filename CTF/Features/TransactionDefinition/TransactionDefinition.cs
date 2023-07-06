using CTF.Models;
using RST.Contracts;

namespace CTF.Features.Models;

public record TransactionDefinition : ITransactionDefinition, IIdentity
{
    public Guid Id { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public string? Payload { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
