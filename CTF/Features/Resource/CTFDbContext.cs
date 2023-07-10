using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.Resource> Resources { get; set; }
    public DbSet<Models.SessionResourceAccess> SessionResources { get; set; }
}
