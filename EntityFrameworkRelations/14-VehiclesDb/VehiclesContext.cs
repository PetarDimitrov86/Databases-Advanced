namespace _14_VehiclesDb
{
    using System.Data.Entity;
    using Models.ChildClasses;
    using Models;

    public class VehiclesContext : DbContext
    {
        public VehiclesContext()
            : base("name=VehiclesContext")
        {
        }
        public virtual IDbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>()
                .HasOptional(t => t.Locomotive)
                .WithRequired(locomotive => locomotive.Train);

            base.OnModelCreating(modelBuilder);
        }
    }
}