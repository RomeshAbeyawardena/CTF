using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    internal void Init_Client(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Client>().HasIndex(c => c.Reference).IsUnique();
        modelBuilder.Entity<Models.Client>().HasIndex(c => c.Name).IsUnique();
    }

    public DbSet<Models.Client> Clients { get; set; }
}
