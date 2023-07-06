using CTF.Models;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(ActivityLog))]
public record ActivityLog : IActivityLog, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid? TransactionId { get; set; }
    public Guid? TransactionDefinitionId { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public DateTimeOffset Created { get; set; }

    public virtual Session? Session { get; set; }
    public virtual Transaction? Transaction { get; set; }
    public virtual TransactionDefinition? TransactionDefinition { get; set; }
    public virtual TransactionType? TransactionType { get; set; }
    
}
