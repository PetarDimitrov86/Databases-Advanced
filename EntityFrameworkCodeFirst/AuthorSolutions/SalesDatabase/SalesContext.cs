namespace SalesDatabase
{
    using System.Data.Entity;
    using SalesDatabase.Models;

    public class SalesContext : DbContext
    {

        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SalesContext>());
            this.Database.Initialize(true);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<StoreLocation> StoreLocations { get; set; }
    }
}