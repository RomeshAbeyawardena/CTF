using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.TransactionType> TransactionType { get; set; }
}
