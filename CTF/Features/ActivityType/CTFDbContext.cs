using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    private static void Init_ActivityType(ModelBuilder builder)
    {
        builder.Entity<Models.ActivityType>().HasIndex(a => a.Name).IsUnique();
    }

    public DbSet<Models.ActivityType> ActivityTypes { get; set; }
}
