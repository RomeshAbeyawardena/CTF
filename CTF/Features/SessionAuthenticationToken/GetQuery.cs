using MediatR;

namespace CTF.Features.SessionAuthenticationToken;

public record GetQuery : IRequest<IQueryable<Models.SessionAuthenticationToken>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? SessionId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool? NoTracking { get; set; }
    public bool ProcessDateRange { get; set; }
}
