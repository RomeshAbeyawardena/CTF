namespace CTF.Api.Features.ActivityType;

public record ActivityType : Models.IActivityType
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool Enabled { get; set; }
}
