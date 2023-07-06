namespace CTF.Features.Session;

public interface IQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    /// <summary>
    /// Gets or sets the owner of the transaction
    /// </summary>
    Guid? OwnerTransactionId { get; set; }
    /// <summary>
    /// Gets or sets the key used to authenticate the session
    /// </summary>
    string? Key { get; set; }
    /// <summary>
    /// Gets or sets the public token used to authenticate the session
    /// </summary>
    string? Token { get; set; }
    /// <summary>
    /// Gets or sets the subject (purpose) of the session
    /// </summary>
    string? Subject { get; set; }
}
