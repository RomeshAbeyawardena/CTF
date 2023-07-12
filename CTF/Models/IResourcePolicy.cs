using RST.Contracts;

namespace CTF.Models;

public interface IResourcePolicy : ICreated
{
    Guid ResourceId { get; set; }
    Guid PolicyId { get; set; }
    string? Name { get; set; }
    DateTimeOffset? ValidTo { get; set; }
}
