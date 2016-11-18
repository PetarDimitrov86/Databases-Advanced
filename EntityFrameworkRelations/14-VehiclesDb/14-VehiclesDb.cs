namespace _14_VehiclesDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehiclesContext context = new VehiclesContext();
            context.Database.Initialize(true);
            context.SaveChanges();
        }
    }
}