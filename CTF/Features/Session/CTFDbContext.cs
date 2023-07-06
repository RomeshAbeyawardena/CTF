using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.Session> Sessions { get; set; }
}
