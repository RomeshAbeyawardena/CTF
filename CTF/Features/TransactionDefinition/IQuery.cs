namespace CTF.Features.TransactionDefinition;

public interface IQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    Guid? ClientId { get; set; }
    string? Key { get; set; }
    string? Token { get; set; }
    string? Subject { get; set; }
}
