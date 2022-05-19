using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ebank.Data.Models
{
    public class EbDbContext : DbContext, IDbContext
    {
        public EbDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>().HasKey(x => x.AccountNumber);
            modelBuilder.Entity<Account>().Property(x => x.AccountNumber).ValueGeneratedNever();

            modelBuilder.Entity<Account>().HasMany(x => x.Transactions)
                .WithOne()
                .HasForeignKey(p => p.AccountNumber);

            base.OnModelCreating(modelBuilder);
        }

    }
}
