namespace ProductShop.Queries
{
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    public class Queries
    {
        static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            ExportProductsInRange(context);
            ExportSoldProducts(context);
            ExportCategoriesByProductCount(context);
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

            var xmlDocument = new XElement("products");

            foreach (var product in productsInRange)
            {
                var productNode =new XElement("product");
                productNode.Add(new XAttribute("name", product.name));
                productNode.Add(new XAttribute("price", product.price));
                productNode.Add(new XAttribute("seller", product.seller));

                xmlDocument.Add(productNode);
            }
            xmlDocument.Save("..//..//..//ExportedDatasets//productsInRange.xml");
        }

        //02 - Successfully Sold Products
        private static void ExportSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(user => user.ProductsSold.Any(prod => prod.Buyer != null))
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .Select(user => new
                {
                    first_name = user.FirstName,
                    last_name = user.LastName,
                    sold_products = user.ProductsSold.Select(prod => new
                    {
                        name = prod.Name,
                        price = prod.Price,
                        buyer_first_name = prod.Buyer.FirstName,
                        buyer_last_name = prod.Buyer.LastName
                    })
                });

            var xmlDocument = new XElement("users");

            foreach (var user in soldProducts)
            {
                var userNode = new XElement("user");

                if (user.first_name != null)
                {
                    userNode.Add(new XAttribute("first-name", user.first_name));
                }

                userNode.Add(new XAttribute("last-name", user.last_name));

                var productsNode = new XElement("sold-products");
                foreach (var product in user.sold_products)
                {
                    var productNode = new XElement("product");
                    productNode.Add(new XElement("name", product.name));
                    productNode.Add(new XElement("price", product.price));

                    if (product.buyer_first_name != null)
                    {
                        productNode.Add(new XElement("buyer-first-name", product.buyer_first_name));
                    }

                    if (product.buyer_last_name != null)
                    {
                        productNode.Add(new XElement("buyer-last-name", product.buyer_last_name));
                    }

                    productsNode.Add(productNode);
                }

                userNode.Add(productsNode);
                xmlDocument.Add(userNode);
            }
            xmlDocument.Save("..//..//..//ExportedDatasets//soldProducts.xml");
        }

        //03 - Categories By Products Count
        private static void ExportCategoriesByProductCount(ProductShopContext context)
        {
            var CategoriesByProductsCount = context.Categories
                .OrderByDescending(cat => cat.Products.Count)
                .Select(cat => new
                {
                    name = cat.Name,
                    products_Count = cat.Products.Count,
                    average_Price = cat.Products.Average(prod => prod.Price),
                    total_Revenue = cat.Products.Sum(prod => prod.Price)
                });

            var xmlDocument = new XElement("categories");

            foreach (var category in CategoriesByProductsCount)
            {
                var categoryNode = new XElement("category");

                categoryNode.Add(new XAttribute("name", category.name));
                categoryNode.Add(new XElement("products-count", category.products_Count));
                categoryNode.Add(new XElement("average-price", category.average_Price));
                categoryNode.Add(new XElement("total-revenue", category.total_Revenue));

                xmlDocument.Add(categoryNode);
            }
            
            xmlDocument.Save("..//..//..//ExportedDatasets//categoriesByProductCount.xml");
        }

        //04 - Users and Products
        private static void ExportUsersAndProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(user => user.ProductsSold.Count > 0)
                .OrderByDescending(user => user.ProductsSold.Count)
                .ThenBy(user => user.LastName)
                .Select(user => new
                {
                    first_name = user.FirstName,
                    last_name = user.LastName,
                    age = user.Age,
                    sold_products = user.ProductsSold.Select(prod => new
                    {
                        name = prod.Name,
                        price = prod.Price
                    })
                });

            var xmlDocument = new XElement("users");
            xmlDocument.Add(new XAttribute("count", usersWithSoldProducts.Count()));

            foreach (var user in usersWithSoldProducts)
            {
                var userNode = new XElement("user");
                if (user.first_name != null)
                {
                    userNode.Add(new XAttribute("first-name", user.first_name));
                }
                userNode.Add(new XAttribute("last-name", user.last_name));
                userNode.Add(new XAttribute("age", user.age));

                var productsNode = new XElement("sold-products");
                productsNode.Add(new XAttribute("count", user.sold_products.Count()));

                foreach (var product in user.sold_products)
                {
                    var productNode = new XElement("product");
                    productNode.Add(new XAttribute("name", product.name));
                    productNode.Add(new XAttribute("price", product.price));

                    productsNode.Add(productNode);
                }

                userNode.Add(productsNode);
                xmlDocument.Add(userNode);
            }

            xmlDocument.Save("..//..//..//ExportedDatasets//UsersWhoSoldProducts.xml");
        }
    }
}
