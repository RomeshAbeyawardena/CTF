using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.TransactionDefinition> TransactionDefinitions { get; set; }
}
