namespace CTF.Models;

public interface IClient
{
    Guid? ParentClientId { get; set; }
    string? Reference { get; set; }
    string? Name { get; set; }
    string? DisplayName { get; set; }
}
