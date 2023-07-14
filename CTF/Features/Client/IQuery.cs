namespace CTF.Features.Client;

public interface IQuery
{
    Guid? Id { get; set; }
    Guid? ParentClientId { get; set; }
    string? NameSearch { get; set; }
}
