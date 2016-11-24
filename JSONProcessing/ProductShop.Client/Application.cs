using ProductShop.Data;

namespace ProductShop.Client
{
    public class Application
    {
        static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.Initialize(true);
            context.SaveChanges();
        }
    }
}