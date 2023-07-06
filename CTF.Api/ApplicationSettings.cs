using CTF.Models;

namespace CTF.Api;

public record ApplicationSettings : IApplicationSettings
{
    public ApplicationSettings(IConfiguration configuration)
    {
        configuration.Bind(this);
        ConnectionString = !string.IsNullOrWhiteSpace(DefaultConnectionStringName) 
            ?  configuration.GetConnectionString(DefaultConnectionStringName) : null;
    }
    
    public string? DefaultConnectionStringName { get; set; }
    public string? ConnectionString { get; }
    public bool LogActivity { get; set; }
}
