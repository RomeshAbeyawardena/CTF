using CTF.Models;
using RST.Contracts;

namespace CTF.Features.Models;

public record TransactionType : ITransactionType, IIdentity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
