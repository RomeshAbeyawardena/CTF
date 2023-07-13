namespace CTF.Features.Resource;

public interface IQuery
{
    Guid? ClientId { get; set; }
    string? NameSearch { get; set; }
    bool? ShowAll { get; set; }
}
