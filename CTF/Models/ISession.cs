namespace CTF.Models;

/// <summary>
/// Represents a session
/// </summary>
public interface ISession
{
    Guid? ClientId { get; set; }
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
    /// <summary>
    /// Gets or sets the valid from timestamp
    /// </summary>
    DateTimeOffset? ValidFrom { get; set; }
    /// <summary>
    /// Gets or sets the valid to timestamp
    /// </summary>
    DateTimeOffset? ValidTo { get; set; }
}
