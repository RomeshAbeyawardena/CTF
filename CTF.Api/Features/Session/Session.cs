namespace CTF.Api.Features.Session;

public record Session : Models.ISession
{
    public Guid? Id { get; set; }
    public Guid? OwnerTransactionId { get; set; }
    public string? Key { get; set; }
    public string? Token { get; set; }
    public string? Subject { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
