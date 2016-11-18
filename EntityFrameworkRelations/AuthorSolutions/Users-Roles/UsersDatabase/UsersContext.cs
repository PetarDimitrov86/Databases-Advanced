namespace UsersDatabase
{
    using System;
    using System.Collections.Generic;
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

        public DbSet<Tag> Tags { get; set; }

        private DbSet<Picture> Pictures { get; set; }

        private DbSet<Album> Albums { get; set; }

        public ICollection<Album> GetOwnAlbumsForUser(User user)
        {
            ICollection<Album> ownAlbums = new List<Album>();
            foreach (UserAlbum userAlbum in user.UserAlbums)
            {
                if (userAlbum.UserRole == "Owner")
                {
                    ownAlbums.Add(userAlbum.Album);
                }
            }

            return ownAlbums;
        }

        public IReadOnlyCollection<ReadOnlyAlbum> GetPublicAlbumsForUser(User user)
        {
            ICollection<ReadOnlyAlbum> publicAlbums = new List<ReadOnlyAlbum>();
            foreach (var userAlbum in user.UserAlbums)
            {
                if (userAlbum.UserRole == "Viewer")
                {
                    publicAlbums.Add(new ReadOnlyAlbum(userAlbum.Album));
                }
            }

            return (IReadOnlyCollection<ReadOnlyAlbum>)publicAlbums;
        }

        public void AddOwnAlbumToUser(User user, Album album)
        {
            user.UserAlbums.Add(new UserAlbum()
            {
                Album = album,
                User = user,
                UserRole = "Owner"
            });
        }

        public void AddPublicAlbumForUser(User user, Album album)
        {
            user.UserAlbums.Add(new UserAlbum()
            {
                Album = album,
                User = user,
                UserRole = "Viewer"
            });
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ReadOnlyAlbum>();

            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(configuration =>
                {
                    configuration.MapLeftKey("UserId");
                    configuration.MapRightKey("FriendId");
                    configuration.ToTable("UserFriends");
                    configuration.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}