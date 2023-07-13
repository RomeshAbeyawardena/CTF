using CTF.Models;

namespace CTF.Api.Features.Models;

public class TransactionDefinition : ITransactionDefinition
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public string? Payload { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
