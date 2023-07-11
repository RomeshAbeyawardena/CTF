using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    private void Init_TransactionType(ModelBuilder builder)
    {
        builder.Entity<Models.TransactionType>().HasIndex(a => a.Name).IsUnique();
    }

    public DbSet<Models.TransactionType> TransactionType { get; set; }
}
