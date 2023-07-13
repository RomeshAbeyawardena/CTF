namespace CTF.Features.Policy;

public interface IQuery
{
    Guid? ClientId { get; set; }
    string? NameSearch { get; }
    bool? HasPublicAccess { get; set; }
    bool? CanRead { get; set; }
    bool? CanWrite { get; set; }
    bool? CanDelete { get; set; }
}
