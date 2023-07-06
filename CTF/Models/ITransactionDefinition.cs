namespace CTF.Models;

/// <summary>
/// Represents the transaction definition
/// </summary>
public interface ITransactionDefinition
{
    /// <summary>
    /// Gets or sets the key used for the transaction definition
    /// </summary>
    string? Key { get; set; }
    /// <summary>
    /// Gets or sets the public token used for transaction definition
    /// </summary>
    string? Token { get; set; }
    /// <summary>
    /// Gets or sets the subject (purpose) of the transaction definition
    /// </summary>
    string? Subject { get; set; }
    /// <summary>
    /// Gets or sets the data
    /// </summary>
    string? Payload { get; set; }
    /// <summary>
    /// Gets or sets the valid from timestamp
    /// </summary>
    DateTimeOffset? ValidFrom { get; set; }
    /// <summary>
    /// Gets or sets the valid to timestamp
    /// </summary>
    DateTimeOffset? ValidTo { get; set; }
}
