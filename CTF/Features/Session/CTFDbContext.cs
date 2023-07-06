using Microsoft.EntityFrameworkCore;

namespace CTF.Features;

public partial class CTFDbContext
{
    public DbSet<Models.Session> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Session>().HasOne(s => s.OwnerTransaction).WithMany().HasForeignKey(v => v.OwnerTransactionId);
        base.OnModelCreating(modelBuilder);
    }
}
