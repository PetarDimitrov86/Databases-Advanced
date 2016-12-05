namespace CarDealer.Client
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            //ImportData();
                  OrderedCustomers();
        }

        private static void OrderedCustomers()
        {
            CarDealerContext context = new CarDealerContext();
            var customers = context.Customers
                .OrderBy(customer => customer.BirthDate)
                .ThenByDescending(customer => customer.IsYoungDriver);
            Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));
        }

        private static void SalesWithPrices()
        {
            using (var context = new CarDealerContext())
            {

                var salesDiscount = context.Sales.Select(s => new
                {
                    car = new { s.Car.Make, s.Car.Model, s.Car.TravelledDistance },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.Parts.Sum(p => p.Price),
                    priceWithDiscount = (s.Car.Parts.Sum(p => p.Price)) - (s.Car.Parts.Sum(p => p.Price) * s.Discount)
                });
                var json = JsonConvert.SerializeObject(salesDiscount, Formatting.Indented);
                //File.WriteAllText("../../sales-discounts.json", json);
                Console.WriteLine(json);
            }
        }

        private static void LocalSuppliers()
        {
            using (var context = new CarDealerContext())
            {

                var localSuppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        partsCount = s.Parts.Count()
                    });
                var json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        private static void TotalSalesByCustomer()
        {
            using (var context = new CarDealerContext())
            {
                var customerSales = context.Customers
                    .Where(c => c.Sales.Any())
                    .Select(c => new
                    {
                        fullName = c.Name,
                        boughtCars = c.Sales.Count,
                        spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                    })
                    .OrderByDescending(c => c.spentMoney)
                    .ThenByDescending(c => c.boughtCars)
                    .ToList();
                var json = JsonConvert.SerializeObject(customerSales, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        private static void CarsAndParts()
        {
            using (var context = new CarDealerContext())
            {
                var carsAndParts = context.Cars
                    .Select(c => new
                    {
                        car = new
                        {
                            c.Make,
                            c.Model,
                            c.TravelledDistance,
                            price = c.Parts.Sum(p => p.Price)
                        },
                        parts = c.Parts.Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                    });
                var json = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        private static void CarsFromMakeToyota()
        {
            using (var context = new CarDealerContext())
            {
                var toyotaCars = context.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(car => new
                    {
                        car.Id,
                        car.Make,
                        car.Model,
                        car.TravelledDistance
                    });
                var json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        static void ImportData()
        {
            ImportSuppliers();
            ImportParts();
            ImportCars();
            ImportCustomers();
            ImportSales();
        }

        static IEnumerable<T> ParseJsonCollection<T>(string path)
        {
            string json = File.ReadAllText(path);
            var collection = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return collection;
        }

        private static void ImportCars()
        {
            var cars = ParseJsonCollection<Car>("../../datasets/cars.json");

            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var parts = context.Parts.ToList();
                foreach (var car in cars)
                {
                    int randomPartsCount = rnd.Next(10, 21);
                    for (int i = 0; i < randomPartsCount; i++)
                    {
                        car.Parts.Add(parts[rnd.Next(parts.Count)]);
                    };

                    context.Cars.Add(car);
                }

                context.SaveChanges();
            }
        }

        private static void ImportSales()
        {
            double[] discounts = new double[] { 0, 0.05, 0.10, 0.20, 0.30, 0.40, 0.50 };
            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var cars = context.Cars.ToList();
                var customers = context.Customers.ToList();
                for (int i = 0; i < 50; i++)
                {
                    var car = cars[rnd.Next(cars.Count)];
                    var customer = customers[rnd.Next(customers.Count)];
                    var discount = discounts[rnd.Next(discounts.Length)];
                    if (customer.IsYoungDriver)
                    {
                        discount += 0.05;
                    }

                    Sale sale = new Sale()
                    {
                        Car = car,
                        Customer = customer,
                        Discount = discount
                    };

                    context.Sales.Add(sale);
                }

                context.SaveChanges();
            }
        }

        private static void ImportCustomers()
        {
            var customers = ParseJsonCollection<Customer>("../../datasets/customers.json");
            using (var context = new CarDealerContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        private static void ImportParts()
        {
            var parts = ParseJsonCollection<Part>("../../datasets/parts.json");

            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var suppliers = context.Suppliers.ToList();
                foreach (var part in parts)
                {
                    part.Supplier = suppliers[rnd.Next(suppliers.Count)];
                    context.Parts.Add(part);
                }

                context.SaveChanges();
            }
        }

        private static void ImportSuppliers()
        {
            var suppliers = ParseJsonCollection<Supplier>("../../datasets/suppliers.json");

            using (var context = new CarDealerContext())
            {
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }
        }
    }
}
