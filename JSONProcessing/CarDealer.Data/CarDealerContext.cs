namespace CarDealer.Data
{
    using System.Data.Entity;
    using Models;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Part> Parts { get; set; }

        public virtual IDbSet<Sale> Sales { get; set; }

        public virtual IDbSet<Supplier> Supplies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithMany(c => c.Parts)
                .Map(pc =>
                {
                    pc.MapLeftKey("Part_Id");
                    pc.MapRightKey("Car_Id");
                    pc.ToTable("PartCars");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}