namespace CTF.Features.TransactionType;

public interface IQuery
{
    /// <summary>
    /// Gets or sets the Session ID
    /// </summary>
    Guid? Id { get; set; }
    public string? NameSearch { get; set; }
}
