using CTF.Models;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(Session))]
public record Session : ISession, IIdentity
{
    public Guid? OwnerTransactionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    [Key]public Guid Id { get; set; }
}
