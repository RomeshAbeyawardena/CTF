using CTF.Models;
using RST.Attributes;

namespace CTF.Api;

[Register]
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
    public int SessionAuthenticationTokenValidityPeriodInDays { get; set; }
}
