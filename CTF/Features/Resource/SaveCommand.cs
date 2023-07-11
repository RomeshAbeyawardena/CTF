using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.Resource;

public record SaveCommand : IRequest<Models.Resource>, IResource, IDbCommand
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public bool CommitChanges { get; set; }
}
