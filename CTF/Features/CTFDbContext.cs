using LinqKit;
using Microsoft.EntityFrameworkCore;
using RST.Extensions;

namespace CTF.Features;

public partial class CTFDbContext : DbContext
{
    public CTFDbContext(DbContextOptions<CTFDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Init_ActivityType(modelBuilder);
        Init_Client(modelBuilder);
        Init_Policy(modelBuilder);
        Init_Resource(modelBuilder);
        Init_TransactionType(modelBuilder);
        Init_Sessions(modelBuilder);
    }
}
