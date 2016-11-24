namespace ProductShop.JSONSeed
{
    using System.IO;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Models;

    public class JSONSeed
    {
        private const string categoriesPath = "..//..//..//datasets//categories.json";
        private const string usersPath = "..//..//..//datasets//users.json";
        private const string productsPath = "..//..//..//datasets//products.json";

        static void Main(string[] args)
        {
            //ImportUsers();
            //ImportCategories();
            //ImportProducts();
        }

        private static void ImportProducts()
        {
            int counter = 0;
            ProductShopContext context = new ProductShopContext();
            var json = File.ReadAllText(productsPath);
            var productsEntities = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            foreach (var product in productsEntities)
            {
                if (counter % 8 != 0)
                {
                    product.Buyer = context.Users
                            .FirstOrDefault(u => u.Id == counter % context.Users.Count());
                }
                int num = counter + 1 %context.Users.Count();
                product.Seller = context.Users
                        .FirstOrDefault(u => u.Id == (counter + 4) % context.Users.Count());
                counter++;
                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        private static void ImportCategories()
        {
            ProductShopContext context = new ProductShopContext();
            var json = File.ReadAllText(categoriesPath);
            var categoriesEntities = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);

            foreach (var category in categoriesEntities)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();
        }

        private static void ImportUsers()
        {
            ProductShopContext context = new ProductShopContext();
            var json = File.ReadAllText(usersPath);
            var usersEntities = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

            foreach (var user in usersEntities)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}