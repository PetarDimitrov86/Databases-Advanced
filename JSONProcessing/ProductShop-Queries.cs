namespace ProductShop.Queries
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Data;

    public class Queries
    {
        static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            ExportProductsInRange(context);
            ExportUsersWhoSoldAtLeastOneProduct(context);
            ExportProductsByCategoryCount(context);
            ExportUsersAndProducts(context);
        }

        //01 - Products In Range
        private static void ExportProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(prod => prod.Price <= 1000 && prod.Price >= 500 && prod.Buyer == null)
                .OrderBy(prod => prod.Price)
                .Select(prod => new
                {
                    name = prod.Name,
                    price = prod.Price,
                    seller = prod.Seller.FirstName + " " + prod.Seller.LastName
                });

            var productsAsJSON = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedFiles//productsInRange.json", productsAsJSON);
        }

        //02 - Successfully Sold Products
        private static void ExportUsersWhoSoldAtLeastOneProduct(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Count(p => p.Buyer != null) > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                });

            var usersAsJSON = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedFiles//usersWhoSoldAtLeastOneProduct.json", usersAsJSON);
        }

        private static void ExportProductsByCategoryCount(ProductShopContext context)
        {
            var categoriesByProductsSoldCount = context.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });

            var categoriesAsJSON = JsonConvert.SerializeObject(categoriesByProductsSoldCount, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedFiles//CategoriesByMostSoldProducts.json", categoriesAsJSON);
        }

        private static void ExportUsersAndProducts(ProductShopContext context)
        {
            var usersWithSoldProduts = context.Users
                .Select(users => new
                {
                    usersCount = context.Users.Count(),
                    users = context.Users
                                    .Where(u => u.ProductsSold.Count > 0)
                                    .OrderByDescending(u => u.ProductsSold.Count)
                                    .ThenBy(u => u.LastName)
                                    .Select(u => new
                                    {
                                        firstName = u.FirstName,
                                        lastName = u.LastName,
                                        age = u.Age,
                                        soldProducts = new
                                        {
                                            count = u.ProductsSold.Count,
                                            products = u.ProductsSold.Select(p => new
                                            {
                                                name = p.Name,
                                                price = p.Price
                                            })
                                        }
                                    })
                });
            var usersAsJSON = JsonConvert.SerializeObject(usersWithSoldProduts, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedFiles//UsersAndTheirProducts.json", usersAsJSON);
        }
    }
}