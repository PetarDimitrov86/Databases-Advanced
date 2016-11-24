namespace JSONImportData
{
    using CarDealer.Data;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class Queries
    {
        static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            ExportCustomers(context);
            ExportCars(context);
            ExportSuppliers(context);
            ExportCarsWithTheirParts(context);
            ExportTotalSalesByCustomer(context);
            ExportSalesWithDiscout(context);
        }
    
        //01 - Ordered Customers
        private static void ExportCustomers(CarDealerContext context)
        {
            var orderderCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver,
                    Sales = "[]"
                });

            var customersAsJson = JsonConvert.SerializeObject(orderderCustomers, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//orderedBirthDateCustomers.json", customersAsJson);
        }

        //02 - Cars from Make Toyota
        private static void ExportCars(CarDealerContext context)
        {
            var carsFromToyota = context.Cars
                .Where(car => car.Make == "Toyota")
                .OrderBy(car => car.Model)
                .ThenByDescending(car => car.TravelledDistance)
                .Select(car => new
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                });

            var toyotaCarsAsJson = JsonConvert.SerializeObject(carsFromToyota, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//toyotaCarsByModel.json", toyotaCarsAsJson);
        }

        //03 - Local Suppliers
        private static void ExportSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(sup => sup.IsImporter == false)
                .Select(sup => new
                {
                    Id = sup.Id,
                    Name = sup.Name,
                    partsCount = sup.Parts.Count
                });

            var localSuppliersAsJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//localSuppliers.json", localSuppliersAsJson);
        }

        //04 - Cars with Their List Of Parts
        private static void ExportCarsWithTheirParts(CarDealerContext context)
        {
            var carsAndTheirParts = context.Cars
                .Select(car => new
                {
                    car = new
                    {
                        Make = car.Make,
                        Model = car.Model,
                        TravelledDistance = car.TravelledDistance,
                        parts = car.Parts.Select(part => new
                        {
                            Name = part.Name,
                            Price = part.Price
                        })
                    }
                });

            var carsAndPartsAsJson = JsonConvert.SerializeObject(carsAndTheirParts, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//carsAndTheirParts.json", carsAndPartsAsJson);
        }

        //05 - Total Sales By Customer
        private static void ExportTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomer = context.Customers
                .Where(cust => cust.Sales.Count > 0)
                .OrderByDescending(cust => cust.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price)))
                .ThenByDescending(cust => cust.Sales.Count(sale => sale.Customer.Id == cust.Id))
                .Select(cust => new
                {
                    fullName = cust.Name,
                    boughtCars = cust.Sales.Count(sale => sale.Customer.Id == cust.Id),
                    spentMoney = cust.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price))
                });

            var salesByCustomerAsJson = JsonConvert.SerializeObject(salesByCustomer, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//totalSalesByCustomer.json", salesByCustomerAsJson);
        }

        //06 - Sales With Applied Discount
        private static void ExportSalesWithDiscout(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Select(sale => new
                {
                    car = new
                    {
                        Make = sale.Car.Make,
                        Model = sale.Car.Model,
                        TravelledDistance = sale.Car.TravelledDistance
                    },
                    customerName = sale.Customer.Name,
                    Discount = sale.Discount,
                    price = sale.Car.Parts.Sum(part => part.Price),
                    priceWithDiscount = sale.Car.Parts.Sum(part => part.Price)* (1 - sale.Discount)
                });

            var salesWithDiscountAsJson = JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
            File.WriteAllText("..//..//..//ExportedResults//SalesWithAppliedDiscount.json", salesWithDiscountAsJson);
        }
    }
}