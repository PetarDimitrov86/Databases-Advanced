namespace PhotoShare.Data
{
    using Interfaces;
    using Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoShareContext context;

        private IRepository<Album> albums;
        private IRepository<AlbumRole> albumRoles;
        private IRepository<Picture> pictures;
        private IRepository<Tag> tags;
        private IRepository<Town> towns;
        private IRepository<User> users;

        public UnitOfWork()
        {
            this.context = new PhotoShareContext();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.albums ?? (this.albums = new Repository<Album>(this.context.Albums));
            }
        }

        public IRepository<AlbumRole> AlbumRoles
        {
            get
            {
                return this.albumRoles ?? (this.albumRoles = new Repository<AlbumRole>(this.context.AlbumRoles));
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.pictures ?? (this.pictures = new Repository<Picture>(this.context.Pictures));
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new Repository<Tag>(this.context.Tags));
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.towns ?? (this.towns = new Repository<Town>(this.context.Towns));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.users ?? (this.users = new Repository<User>(this.context.Users));
            }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}