using CTF.Models;

namespace CTF.Api.Features.Models;

public class TransactionType : ITransactionType
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
