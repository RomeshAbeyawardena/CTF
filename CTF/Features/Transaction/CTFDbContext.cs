using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.Transaction> Transactions { get; set; }
}
