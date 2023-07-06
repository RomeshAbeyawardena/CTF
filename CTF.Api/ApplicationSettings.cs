namespace CTF.Api;

public record ApplicationSettings
{
    public ApplicationSettings(IConfiguration configuration)
    {
        configuration.Bind(this);
        ConnectionString = !string.IsNullOrWhiteSpace(DefaultConnectionStringName) 
            ?  configuration.GetConnectionString(DefaultConnectionStringName) : null;
    }
    public string? DefaultConnectionStringName { get; set; }
    public string? ConnectionString { get; }
}
