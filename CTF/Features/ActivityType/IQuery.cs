namespace CTF.Features.ActivityType;

public interface IQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    string? NameSearch { get; set; }
    Enumerations.ActivityType? ActivityType { get; set; }
}
