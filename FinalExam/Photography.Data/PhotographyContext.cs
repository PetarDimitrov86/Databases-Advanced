namespace Photography.Data
{
    using Models;
    using System.Data.Entity;

    public class PhotographyContext : DbContext
    {
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
        }
         public virtual DbSet<Accessory> Accessories { get; set; }

         public virtual DbSet<Camera> Cameras { get; set; }

         public virtual DbSet<Lens> Lenses { get; set; }

         public virtual DbSet<Photographer> Photographers { get; set; }

         public virtual DbSet<Workshop> Workshops { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lens>().Property(lens => lens.MaxAperture).HasPrecision(18, 1);

            modelBuilder.Entity<Photographer>()
                .HasRequired(photographer => photographer.PrimaryCamera)
                .WithMany(camera => camera.PrimaryCameraOwners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasRequired(photographer => photographer.SecondaryCamera)
                .WithMany(camera => camera.SecondaryCameraOwners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasMany(phot => phot.ParticipantWorkshops)
                .WithMany(workshop => workshop.Participants)
                .Map(config =>
                {
                    config.MapLeftKey("PhotographerId");
                    config.MapRightKey("WorkshopId");
                    config.ToTable("PhotographersWorkshops");
                });

            modelBuilder.Entity<Workshop>()
                .HasRequired(workshop => workshop.Trainer)
                .WithMany(trainer => trainer.TrainerWorkshops)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}