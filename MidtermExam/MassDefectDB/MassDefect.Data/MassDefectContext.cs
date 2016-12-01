namespace MassDefect.Data
{
    using System.Data.Entity;
    using Models;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }
        
        public virtual IDbSet<Anomaly> Anomalies { get; set; }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }
        
        public virtual IDbSet<SolarSystem> SolarSystems { get; set; }

        public virtual IDbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Person>()
               .HasMany<Anomaly>(person => person.Anomalies)
                .WithMany(anomaly => anomaly.Victims)
                .Map(pa =>
                {
                //MapLeft should be for the class in modelBuilder.Entity<Person>()
                    pa.MapLeftKey("PersonId");
                    pa.MapRightKey("AnomalyId");
                    pa.ToTable("AnomalyVictims");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
