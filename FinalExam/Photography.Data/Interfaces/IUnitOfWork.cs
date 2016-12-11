namespace Photography.Data.Interfaces
{
    using Models;

    public interface IUnitOfWork
    {
        IRepository<Accessory> Accessories { get; }

        IRepository<Camera> Cameras { get; }

        IRepository<Lens> Lenses { get; }
        
        IRepository<Photographer> Photographers { get; }
        
        IRepository<Workshop> Workshops { get; }
        
        void Commit();
    }
}