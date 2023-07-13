using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.Client;

public record SaveCommand : IRequest<Models.Client>, IClient, IDbCommand
{
    public Guid? Id { get; set; }
    public Guid? ParentClientId { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool CommitChanges { get; set; }
}
