using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    private void Init_Sessions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Session>()
            .HasOne(s => s.OwnerTransaction)
            .WithMany()
            .HasForeignKey(v => v.OwnerTransactionId);
    }

    public DbSet<Models.Session> Sessions { get; set; }
}
