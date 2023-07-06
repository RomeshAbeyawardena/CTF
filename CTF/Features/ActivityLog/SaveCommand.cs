using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.ActivityLog;

public class SaveCommand : IRequest<Models.ActivityLog>, IActivityLog, IDbCommand
{
    public Guid? Id { get; set; }
    public bool CommitChanges { get; set; }
    public Guid SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset Created { get; set; }
}
