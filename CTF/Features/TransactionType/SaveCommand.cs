using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.TransactionType;

public class SaveCommand : IRequest<Models.TransactionType>, ITransactionType, IDbCommand
{
    public Guid? Id { get; set; }
    public bool CommitChanges { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
