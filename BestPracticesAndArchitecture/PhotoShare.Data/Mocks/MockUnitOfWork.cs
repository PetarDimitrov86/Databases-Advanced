using PhotoShare.Data.Interfaces;
using PhotoShare.Models;

namespace PhotoShare.Data.Mocks
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private IRepository<Album> albums;
        private IRepository<AlbumRole> albumRoles;
        private IRepository<Picture> pictures;
        private IRepository<Tag> tags;
        private IRepository<Town> towns;
        private IRepository<User> users;

        public IRepository<Album> Albums
        {
            get
            {
                return this.albums ?? (this.albums = new MockRepository<Album>());
            }
        }

        public IRepository<AlbumRole> AlbumRoles
        {
            get
            {
                return this.albumRoles ?? (this.albumRoles = new MockRepository<AlbumRole>());
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.pictures ?? (this.pictures = new MockRepository<Picture>());
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new MockRepository<Tag>());
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.towns ?? (this.towns = new MockRepository<Town>());
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.users ?? (this.users = new MockRepository<User>());
            }
        }

        public void Commit()
        {
        }
    }
}