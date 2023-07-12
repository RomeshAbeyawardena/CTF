namespace CTF.Models;

public interface IApplicationSettings
{
    int SessionAuthenticationTokenValidityPeriodInDays { get; set; }
    bool LogActivity { get; set; }
    string? DefaultConnectionStringName { get; set; }
    string? ConnectionString { get; }
}
