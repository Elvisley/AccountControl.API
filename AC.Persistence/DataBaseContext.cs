using AC.Domain;
using AC.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AC.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonLegalConfig());
            modelBuilder.ApplyConfiguration(new PersonPhysicalConfig());
            modelBuilder.ApplyConfiguration(new AccountsConfig());
            modelBuilder.ApplyConfiguration(new ChildrenAccountsConfig());
            modelBuilder.ApplyConfiguration(new TransactionsTypeConfig());
            modelBuilder.ApplyConfiguration(new TransactionsConfig());
        }
    }
}
