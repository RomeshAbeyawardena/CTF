namespace CTF.Models;

public interface IApplicationSettings
{
    bool LogActivity { get; set; }
    string? DefaultConnectionStringName { get; set; }
    string? ConnectionString { get; }
}
