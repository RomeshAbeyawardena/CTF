using CTF.Models;
using RST.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models;

[Table(nameof(SessionResourceAccess))]
public record SessionResourceAccess : ISessionResourceAccess, IIdentity
{
    [Key]
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid ResourceId { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public DateTimeOffset Created { get; set; }
    public bool IsEnabled { get; set; }

    public virtual Session? Session { get; set; }
    public virtual Resource? Resource { get; set; }
}
