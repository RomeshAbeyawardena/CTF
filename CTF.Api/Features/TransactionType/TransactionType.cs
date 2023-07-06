using CTF.Models;

namespace CTF.Api.Features.TransactionType;

public class TransactionType : ITransactionType
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
