namespace CTF.Models;

/// <summary>
/// Represents the transaction type
/// </summary>
public interface IActivityType
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    string? Name { get; set; }
    /// <summary>
    /// Gets or sets the display name
    /// </summary>
    string? DisplayName { get; set; }
    /// <summary>
    /// Gets or sets a value that determines whether the activity type is enabled
    /// </summary>
    bool Enabled { get; set; }
}
