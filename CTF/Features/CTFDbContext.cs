using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext : DbContext
{
    public CTFDbContext(DbContextOptions<CTFDbContext> options)
        : base(options)
    {
        
    }
}
