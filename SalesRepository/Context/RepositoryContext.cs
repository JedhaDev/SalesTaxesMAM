using SalesRepository.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace SalesRepository.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Tax> Taxes { get; set; }


        public RepositoryContext(DbConnection connection) : base(connection, false)
        {
            Database.SetInitializer(new RepositoryDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
