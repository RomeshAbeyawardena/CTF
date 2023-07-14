using MediatR;

namespace CTF.Features.Resource;

public record GetQuery : IRequest<IQueryable<Models.Resource>>, IQuery
{
    public Guid? Id { get; set; }
    public Guid? ClientId { get; set; }
    public string? NameSearch { get; set; }
    public bool? ShowAll { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool FilterByDate { get; set; }
    public bool? NoTracking { get; set; }
    public DateTimeOffset? ImportedDate { get; set; }
}
