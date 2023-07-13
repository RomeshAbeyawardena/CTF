using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.Policy;

public record SaveCommand : IRequest<Models.Policy>, IPolicy, IDbCommand
{
    public Guid? ClientId { get; set; }
    public string? Name { get; set; }
    public bool HasPublicAccess { get; set; }
    public bool CanRead { get; set; }
    public bool CanWrite { get; set; }
    public bool CanDelete { get; set; }
    public bool CommitChanges { get; set; }
    public Guid? Id { get; set; }
}
