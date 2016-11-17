namespace _02_User
{
    using Models;
    using System.Data.Entity;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }
        
        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(usus =>
                {
                    usus.MapLeftKey("UserId");
                    usus.MapRightKey("UserFriendId");
                    usus.ToTable("UsersFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}