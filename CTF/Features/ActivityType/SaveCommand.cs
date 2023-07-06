using CTF.Models;
using MediatR;
using RST.Contracts;

namespace CTF.Features.ActivityType;

public class SaveCommand : IRequest<Models.ActivityType>, IActivityType, IDbCommand
{
    public Guid? Id { get; set; }
    public bool CommitChanges { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
    public Guid SessionId { get; set; }
}
