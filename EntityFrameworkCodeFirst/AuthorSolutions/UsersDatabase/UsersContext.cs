namespace UsersDatabase
{
    using System.Data.Entity;
    using UsersDatabase.Models;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersContext>());
        }         
        public DbSet<User> Users { get; set; }

        public DbSet<Town> Towns { get; set; }
    }
}