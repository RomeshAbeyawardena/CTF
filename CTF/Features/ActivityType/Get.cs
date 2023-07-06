using MediatR;

namespace CTF.Features.ActivityType;

public record Get : IRequest<IQueryable<Models.ActivityType>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; set; }
    public Enumerations.ActivityType? ActivityType { get; set; }
}
