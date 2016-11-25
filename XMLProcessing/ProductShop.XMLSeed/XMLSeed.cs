namespace ProductShop.XMLSeed
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Data;
    using Models;

    public class XMLSeed
    {
        private const string categoriesPath = "..//..//..//datasets//categories.xml";
        private const string productsPath = "..//..//..//datasets//products.xml";
        private const string usersPath = "..//..//..//datasets//users.xml";

        static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.Initialize(true);
            context.SaveChanges();

            ImportUsers(context);
            ImportCategories(context);
            ImportProducts(context);
        }

        private static void ImportUsers(ProductShopContext context)
        {
            var xml = XDocument.Load(usersPath);
            var users = xml.XPathSelectElements("users/user");

            foreach (var user in users)
            {
                ImportUser(user, context);
            }
            context.SaveChanges();
        }

        private static void ImportUser(XElement userNode, ProductShopContext context)
        {
            var firstName = userNode.Attribute("first-name");
            var lastName = userNode.Attribute("last-name");
            int age = 0;

            if (userNode.Attribute("age") != null)
            {
                age = (int)userNode.Attribute("age");
            }

            var user = new User();

            if (firstName == null)
            {
                user = new User
                {
                    LastName = lastName.Value,
                    Age = age
                };
            }
            else
            {
                user = new User
                {
                    FirstName = firstName.Value,
                    LastName = lastName.Value,
                    Age = age
                };
            }            

            context.Users.Add(user);
        }

        private static void ImportCategories(ProductShopContext context)
        {
            var xml = XDocument.Load(categoriesPath);
            var categories = xml.XPathSelectElements("categories/category");

            foreach (var category in categories)
            {
                ImportCategory(category, context);
            }
            context.SaveChanges();
        }

        private static void ImportCategory(XElement category, ProductShopContext context)
        {
            var name = category.Element("name");

            context.Categories.Add(new Category
            {
                Name = name.Value
            });
        }

        private static void ImportProducts(ProductShopContext context)
        {
            var xml = XDocument.Load(productsPath);
            var products = xml.XPathSelectElements("products/product");

            int counter = 0;
            Random rnd = new Random();

            foreach (var productNode in products)
            {
                var name = productNode.Element("name").Value;
                var price = (double)productNode.Element("price");

                int randomBuyerId = rnd.Next(1, context.Users.Count() + 1);
                int randomSellerId = rnd.Next(1, context.Users.Count() + 1);
                User buyer = context.Users.FirstOrDefault(u => u.Id == randomBuyerId );
                User seller = context.Users.FirstOrDefault(u => u.Id == randomSellerId);

                if (counter % 8 == 0)
                {
                    buyer = null;
                }

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    Buyer = buyer,
                    Seller = seller,                  
                };

                int firstRandomCategoryId = rnd.Next(1, context.Categories.Count() + 1);
                int secondRandomCategoryId = rnd.Next(1, context.Categories.Count() + 1);
                int thirdRandomCategoryId = rnd.Next(1, context.Categories.Count() + 1);
                product.Categories.Add(context.Categories.FirstOrDefault(cat => cat.Id == firstRandomCategoryId));
                product.Categories.Add(context.Categories.FirstOrDefault(cat => cat.Id == secondRandomCategoryId));
                product.Categories.Add(context.Categories.FirstOrDefault(cat => cat.Id == thirdRandomCategoryId));

                context.Products.Add(product);
                counter++;
            }

            context.SaveChanges();
        }
    }
}