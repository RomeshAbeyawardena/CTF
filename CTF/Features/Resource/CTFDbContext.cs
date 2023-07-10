using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public static void Init_Resource(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Resource>().HasIndex(r => r.Name);
    }

    public DbSet<Models.Resource> Resources { get; set; }
    public DbSet<Models.SessionResourceAccess> SessionResources { get; set; }
}
