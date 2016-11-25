namespace CarDealer.JSONSeed
{
    using System.Collections.Generic;
    using System.IO;
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class JSONSeed
    {
        private const string SuppliersPath = "..//..//..//datasets//suppliers.json";
        private const string PartsPath = "..//..//..//datasets//parts.json";
        private const string CarsPath = "..//..//..//datasets//cars.json";
        private const string CustomersPath = "..//..//..//datasets//customers.json";

        static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            ImportSupplier(context);
            ImportParts(context);
            ImportCars(context);
            ImportCustomers(context);
            ImportSalesRecords(context);
        }

        private static void ImportSupplier(CarDealerContext context)
        {
            var json = File.ReadAllText(SuppliersPath);
            var supplierEntities = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(json);

            foreach (var supplier in supplierEntities)
            {
                context.Suppliers.Add(supplier);
            }

            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            Random rnd = new Random();
            var json = File.ReadAllText(PartsPath);
            var partsEntities = JsonConvert.DeserializeObject<IEnumerable<Part>>(json);

            foreach (var part in partsEntities)
            {
                int newNumber = rnd.Next(1, context.Suppliers.Count() + 1);
                part.Supplier = context.Suppliers.FirstOrDefault(sup => sup.Id == newNumber);
                context.Parts.Add(part);
            }
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context)
        {
            Random rnd = new Random();

            var json = File.ReadAllText(CarsPath);
            var carsEntities = JsonConvert.DeserializeObject<IEnumerable<Car>>(json);

            foreach (var car in carsEntities)
            {
                int numberOfPartsToAdd = rnd.Next(10, 21);

                for (int i = 0; i < numberOfPartsToAdd; i++)
                {
                    int partIndext = rnd.Next(1, context.Parts.Count() + 1);
                    car.Parts.Add(context.Parts.FirstOrDefault(part => part.Id == partIndext));
                }

                context.Cars.Add(car);
            }

            context.SaveChanges();
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            var json = File.ReadAllText(CustomersPath);
            var CustomerEntities = JsonConvert.DeserializeObject<ICollection<Customer>>(json);

            foreach (var customer in CustomerEntities)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }

        private static void ImportSalesRecords(CarDealerContext context)
        {
            Random rnd = new Random();
            List<decimal> discountRates = new List<decimal> {0, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m};

            foreach (var car in context.Cars)
            {
                int customerId = rnd.Next(1, context.Customers.Count() + 1);
                Customer customerToAdd = context.Customers.FirstOrDefault(customer => customer.Id == customerId);

                decimal discountRate = discountRates[rnd.Next(0, discountRates.Count - 1)];

                if (customerToAdd.IsYoungDriver)
                {
                    discountRate += 0.05m;
                }

                context.Sales.Add(new Sale
                {
                    Car = car,
                    Customer = customerToAdd,
                    Discount = discountRate
                });
            }

            context.SaveChanges();
        }
    }
}
