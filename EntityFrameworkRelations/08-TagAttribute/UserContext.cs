using _07_Tags.Models;

namespace _07_Tags
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserContext : DbContext
    {

        public UserContext()
            : base("name=UserContext")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

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