using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.ActivityType> ActivityTypes { get; set; }

    
}
