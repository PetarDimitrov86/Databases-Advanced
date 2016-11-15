namespace UsersDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UsersDatabase.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersDatabase.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UsersDatabase.UsersContext context)
        {
            context.Towns.AddOrUpdate(town => town.Name,
                new Town()
                {
                    Name = "Asenovgrad",
                    CountryName = "Bulgaria"
                },
                new Town()
                {
                    Name = "Sofia",
                    CountryName = "Bulgaria"
                }, new Town()
                {
                    Name = "Karlovo",
                    CountryName = "Bulgaria"
                }, new Town()
                {
                    Name = "Seattle",
                    CountryName = "USA"
                });
            context.SaveChanges();


            Town asenovgrad = context.Towns.First(town => town.Name == "Asenovgrad");
            Town karlovo = context.Towns.First(town => town.Name == "Sofia");
            Town seattle = context.Towns.First(town => town.Name == "Seattle");
            Town sofia = context.Towns.First(town => town.Name == "Sofia");

            context.Users.AddOrUpdate(user => user.Username, new User
            {
                Age = 15,
                Email = "daspf@abv.com",
                IsDeleted = true,
                LastTimeLoggedIn = new DateTime(1992, 11, 29),
                Password = "hel$A-_99lo",
                //  ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
                Username = "Bai Stenly",
                FirstName = "Stanislav",
                LastName = "Karagiozov",
                BornTown = asenovgrad,
                CurrentlyLivingTown = sofia, 
            },
            new User
            {
                Age = 110,
                Email = "bdas@gam.com",
                IsDeleted = true,
                LastTimeLoggedIn = new DateTime(1993, 1, 20),
                Password = "heds-alA2_lo",
                // ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
                FirstName = "Atanas",
                LastName = "Stamatov",
                BornTown = karlovo,
                CurrentlyLivingTown = seattle,
                Username = "Bai Nasko"
            });
            context.SaveChanges();
        }
    }
}
