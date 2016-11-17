namespace FootballBettingData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FootballBettingModels;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany<Continent>(country => country.Continent)
                .WithMany(continent => continent.Countries)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("CountryId");
                    configuration.MapRightKey("ContinentId");
                    configuration.ToTable("CountryContinents");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}