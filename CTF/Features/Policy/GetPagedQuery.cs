using MediatR;
using RST.Contracts;
using RST.Enumerations;

namespace CTF.Features.Policy;

public record GetPagedQuery : IPagedRequest<Models.Policy>, IQuery
{
    public Guid? Id { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public string? NameSearch { get; }
    public bool? HasPublicAccess { get; set; }
    public bool? CanRead { get; set; }
    public bool? CanWrite { get; set; }
    public bool? CanDelete { get; set; }
}
