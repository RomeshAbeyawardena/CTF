
namespace CTF.Models;

public interface IPolicy
{
    Guid? ClientId { get; set; }
    Guid? Id { get; set; }
    string? Name { get; set; }
    bool HasPublicAccess { get; set; }
    bool CanRead { get; set; }
    bool CanWrite { get; set; }
    bool CanDelete { get; set; }
}
