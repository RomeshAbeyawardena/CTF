using MediatR;

namespace CTF.Features.ActivityType;

public record GetQuery : IRequest<IQueryable<Models.ActivityType>>, IQuery
{
    public Guid? Id { get; set; }
    public string? NameSearch { get; set; }
    public Enumerations.ActivityType? ActivityType { get; set; }
}
