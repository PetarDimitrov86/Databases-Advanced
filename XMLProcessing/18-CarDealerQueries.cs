namespace CarDealer.XMLQueries
{
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    public class XMLQueries
    {
        static void Main(string[] args)
        {
            var context = new CarDealerContext();

            ExportOrderedCustomers(context);
            ExportToyotaCars(context);
            ExportLocalSuppliers(context);
            ExportCarsAndTheirParts(context);
            ExportTotalSalesByCustomer(context);
            ExportSalesWithAppliedDiscounts(context);
        }

        //01 - Ordered Customers
        private static void ExportOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(cust => cust.BirthDate)
                .ThenBy(cust => cust.IsYoungDriver)
                .Select(cust => new
                {
                    id = cust.Id,
                    name = cust.Name,
                    birth_date = cust.BirthDate,
                    is_young_driver = cust.IsYoungDriver
                });

            var xml = new XElement("customers");

            foreach (var customer in customers)
            {
               var customerNode = new XElement("customer");
               customerNode.Add(new XElement("id", customer.id));
               customerNode.Add(new XElement("name", customer.name));
               customerNode.Add(new XElement("birth-date", customer.birth_date));
               customerNode.Add(new XElement("is-young-driver", customer.is_young_driver));

               //Version 2, using params[] object
               //XElement customerNode = new XElement("customer",
               //                            new XElement("id", customer.id),
               //                            new XElement("name", customer.name), 
               //                            new XElement("birth-date", customer.birth_date),
               //                            new XElement("is-young-driver", customer.is_young_driver));

                xml.Add(customerNode);
            }

            xml.Save("..//..//..//ExportedResults//orderedBirthDateCustomers.xml");
        }

        //02 - Cars From Make Toyota
        private static void ExportToyotaCars(CarDealerContext context)
        {
            var carsFromToyota = context.Cars
                .Where(car => car.Make == "Toyota")
                .OrderBy(car => car.Model)
                .ThenByDescending(car => car.TravelledDistance)
                .Select(car => new
                {
                    id = car.Id,
                    make = car.Make,
                    model = car.Model,
                    travelled_distance = car.TravelledDistance
                });

            var xmlDocument = new XElement("cars");

            foreach (var car in carsFromToyota)
            {
                var carNode = new XElement("car");
                carNode.Add(new XAttribute("id", car.id));
                carNode.Add(new XAttribute("make", car.make));
                carNode.Add(new XAttribute("model", car.model));
                carNode.Add(new XAttribute("travelled-distance", car.travelled_distance));

                //Version 2, using params[] object
                //var carNode = new XElement("car",
                //                 new XAttribute("id", car.id),
                //                 new XAttribute("make", car.make),
                //                 new XAttribute("model", car.model),
                //                 new XAttribute("travelled-distance", car.travelled_distance));

                xmlDocument.Add(carNode);       
            }                                   

            xmlDocument.Save("..//..//..//ExportedResults//toyotaCarsByModel.xml");
        }

        //03 - Local Suppliers
        private static void ExportLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(sup => sup.IsImporter == false)
                .Select(sup => new
                {
                    id = sup.Id,
                    name = sup.Name,
                    parts_count = sup.Parts.Count
                });

            var xmlDocument = new XElement("suppliers");

            foreach (var supplier in suppliers)
            {
                var supplierNode = new XElement("supplier");
                supplierNode.Add(new XAttribute("id", supplier.id));
                supplierNode.Add(new XAttribute("name", supplier.name));
                supplierNode.Add(new XAttribute("parts-count", supplier.parts_count));

                xmlDocument.Add(supplierNode);
            }

            xmlDocument.Save("..//..//..//ExportedResults//localSuppliers.xml");
        }

        //04 - Cars with Their List Of Parts
        private static void ExportCarsAndTheirParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(car => new
                {
                    make = car.Make,
                    model = car.Model,
                    travelled_distance = car.TravelledDistance,
                    parts = car.Parts.Select(part => new
                    {
                        name = part.Name,
                        price = part.Price
                    })
                });

            var xmlDocument = new XElement("cars");

            foreach (var car in carsWithParts)
            {
                var carNode = new XElement("car");
                carNode.Add(new XAttribute("make", car.make));
                carNode.Add(new XAttribute("model", car.model));
                carNode.Add(new XAttribute("travelled-distance", car.travelled_distance));

                var partsNode = new XElement("parts");

                foreach (var part in car.parts)
                {
                    var partNode = new XElement("part");
                    partNode.Add(new XAttribute("name", part.name));
                    partNode.Add(new XAttribute("price", part.price));

                    partsNode.Add(partNode);
                }
                carNode.Add(partsNode);
                xmlDocument.Add(carNode);
            }

            xmlDocument.Save("..//..//..//ExportedResults//carsAndTheirParts.xml");
        }

        //05 - Total Sales By Customer
        private static void ExportTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithCars = context.Customers
                .Where(cust => cust.Sales.Count > 0)
                .OrderByDescending(cust => cust.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price)))
                .ThenByDescending(cust => cust.Sales.Count)
                .Select(cust => new
                {
                    full_name = cust.Name,
                    bought_cars = cust.Sales.Count,
                    spent_money = cust.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price))
                });

            var xmlDocument = new XElement("customers");

            foreach (var customer in customersWithCars)
            {
                var customerNode = new XElement("customer");
                customerNode.Add(new XAttribute("full-name", customer.full_name));
                customerNode.Add(new XAttribute("bought-cars", customer.bought_cars));
                customerNode.Add(new XAttribute("spent-money", customer.spent_money));

                xmlDocument.Add(customerNode);
            }

            xmlDocument.Save("..//..//..//ExportedResults//totalSalesByCustomer.xml");
        }

        //06 - Sales With Applied Discount
        private static void ExportSalesWithAppliedDiscounts(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(sale => new
                {
                    make = sale.Car.Make,
                    model = sale.Car.Model,
                    travelled_distance = sale.Car.TravelledDistance,
                    customer_name = sale.Customer.Name,
                    discount = sale.Discount,
                    price = sale.Car.Parts.Sum(part => part.Price),
                    price_with_discount = sale.Car.Parts.Sum(part => part.Price)*(double) (1 - sale.Discount)
                });

            var xmlDocument = new XElement("sales");

            foreach (var sale in sales)
            {
                var saleNode = new XElement("sale");
                
                var carNode = (new XElement("car"));
                carNode.Add(new XAttribute("make", sale.make));
                carNode.Add(new XAttribute("model", sale.model));
                carNode.Add(new XAttribute("travelled-distance", sale.travelled_distance));

                saleNode.Add(carNode);

                saleNode.Add(new XElement("customer-name", sale.customer_name));
                saleNode.Add(new XElement("discount", sale.discount));
                saleNode.Add(new XElement("price", sale.price));
                saleNode.Add(new XElement("price-with-discount", sale.price_with_discount));

                xmlDocument.Add(saleNode);
            }

            xmlDocument.Save("..//..//..//ExportedResults//SalesWithAppliedDiscount.xml");
        }
    }
}