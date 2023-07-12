using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public static void Init_Policy(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Policy>().HasIndex(r => r.Name).IsUnique();
    }
}
