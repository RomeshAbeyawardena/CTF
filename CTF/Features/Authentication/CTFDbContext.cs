using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.SessionAuthenticationToken> SessionAuthenticationTokens { get; set; }
}
