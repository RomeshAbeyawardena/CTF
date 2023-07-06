using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    private void Init_ActivityType(ModelBuilder builder)
    {
        builder.Entity<Models.ActivityType>().HasIndex(a => a.Name);
    }

    public DbSet<Models.ActivityType> ActivityTypes { get; set; }
}
