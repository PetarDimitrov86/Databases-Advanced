namespace PhotoShare.Data.Interfaces
{
    using Models;

    public interface IUnitOfWork
    {
        IRepository<Album> Albums { get; }

        IRepository<AlbumRole> AlbumRoles { get; }

        IRepository<Picture> Pictures { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Town> Towns { get; }

        IRepository<User> Users { get; }

        void Commit();
    }
}