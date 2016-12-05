namespace ProductsShop.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductsShop.Model;
    class Program
    {
        static void Main()
        {
            SeedData();
            QueryAndExportData();

        }

        private static void QueryAndExportData()
        {
            ProductsInRange();
            SuccessfullySoldProducts();
            CategoriesByProductCount();
            UsersAndProducts();
        }

        private static void UsersAndProducts()
        {
            ProductShopContext context = new ProductShopContext();
            var users = context.Users
                .Where(user => user.ProductsSold.Count != 0)
                .OrderByDescending(user => user.ProductsSold.Count)
                .ThenBy(user => user.LastName)
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    user.Age,
                    soldProcuts = new
                    {
                        count = user.ProductsSold.Count,
                        products = user.ProductsSold.Select(product => new
                        {
                            product.Name,
                            product.Price
                        })
                    }
                }).ToArray();
            var jsonToSerialize = new
            {
                usersCount = users.Count(),
                users = users
            };

           ExportToJson(jsonToSerialize, "../../../results/usersAndProducts.json");
        }

        private static void CategoriesByProductCount()
        {
            ProductShopContext context = new ProductShopContext();
            var categoriesWanted = context.Categories
                .OrderBy(cat => cat.Products.Count)
                .Select(cat => new
                {
                    cat.Name,
                    productsCount = cat.Products.Count,
                    averagePrice = cat.Products.Average(product => product.Price),
                    totalRevenue = cat.Products.Sum(product => product.Price)
                });

            ExportToJson(categoriesWanted, "../../../results/categoriesByProductCout.json");
        }

        private static void SuccessfullySoldProducts()
        {
            ProductShopContext context = new ProductShopContext();
            var users = context.Users
                .Where(user => user.ProductsSold.Count(product => product.Buyer != null) != 0)
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    soldProducts = user.ProductsSold.Select(product => new
                    {
                        product.Name,
                        product.Price,
                        buyerFirstName = product.Buyer.FirstName,
                        buyerLastName = product.Buyer.LastName
                    })
                });

            ExportToJson(users, "../../../results/usersWithSoldProducts.json");
        }

        private static void ProductsInRange()
        {
            Console.Write("Please enter a lower boundary for the price range of the product: ");
            decimal lowerBoundary = decimal.Parse(Console.ReadLine());
            Console.Write("Please enter an upper boundary for the price range of the product: ");
            decimal upperBoudary = decimal.Parse(Console.ReadLine());

            ProductShopContext context = new ProductShopContext();
            var products = context.Products
                 .Where(product => product.Price >= lowerBoundary && product.Price <= upperBoudary && product.Buyer == null)
                 .OrderBy(product => product.Price)
                 .Select(product => new
                 {
                     product.Name,
                     product.Price,
                     seller = product.Seller.FirstName + " " + product.Seller.LastName
                 });
            ExportToJson(products, "../../../results/productsInRange.json");
        }

        private static void ExportToJson<TEntity>(TEntity entity, string path)
        {
            string jsonProducts = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(path, jsonProducts);
        }

        private static void SeedData()
        {
            SeedUsers();
            SeedProducts();
            SeedCategories();
        }

        private static void SeedCategories()
        {
            ProductShopContext context = new ProductShopContext();
            string json = File.ReadAllText("../../../datasets/categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
            int countOfProducts = context.Products.Count();
            Random rnd = new Random();
            foreach (Category category in categories)
            {
                for (int i = 0; i < countOfProducts / 3; i++)
                {
                    Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedUsers()
        {
            ProductShopContext context = new ProductShopContext();
            string json = File.ReadAllText("../../../datasets/users.json");
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedProducts()
        {
            ProductShopContext context = new ProductShopContext();
            string json = File.ReadAllText("../../../datasets/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            Random rnd = new Random();
            foreach (Product product in products)
            {
                double shouldHaveBuyer = rnd.NextDouble();
                product.SelledId = rnd.Next(1, context.Users.Count() + 1);
                if (shouldHaveBuyer <= 0.7)
                {
                    product.BuyerId = rnd.Next(1, context.Users.Count() + 1);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

    }
}
