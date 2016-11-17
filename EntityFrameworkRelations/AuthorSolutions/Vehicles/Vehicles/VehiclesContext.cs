namespace Vehicles
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Vehicles.Models;
    using Vehicles.Models.MotorVehicles;

    public class VehiclesContext : DbContext
    {
        public VehiclesContext()
            : base("name=VehiclesContext")
        {
        }

        public IDbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>()
                .HasOptional(tr => tr.Locomotive)
                .WithRequired(locomotive => locomotive.Train);

            base.OnModelCreating(modelBuilder);
        }
    }
}