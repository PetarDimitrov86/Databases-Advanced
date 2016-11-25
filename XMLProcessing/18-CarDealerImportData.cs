using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealer.XMLSeed
{
    public class XMLSeed
    {
        private const string SuppliersPath = "..//..//..//datasets//suppliers.xml";
        private const string PartsPath = "..//..//..//datasets//parts.xml";
        private const string CarsPath = "..//..//..//datasets//cars.xml";
        private const string CustomersPath = "..//..//..//datasets//customers.xml";

        static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.Initialize(true);
            context.SaveChanges();

            ImportSuppliers(context);
            ImportParts(context);
            ImportCars(context);
            ImportCustomers(context);
            ImportSalesRecords(context);
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            XDocument xml = XDocument.Load(SuppliersPath);
            var suppliers = xml.XPathSelectElements("suppliers/supplier");

            foreach (var supplier in suppliers)
            {
                ImportSupplier(supplier, context);
            }
            context.SaveChanges();
        }

        private static void ImportSupplier(XElement supplierNode, CarDealerContext context)
        {
            var name = supplierNode.Attribute("name");
            var is_importer = supplierNode.Attribute("is-importer");

            Supplier supplier = new Supplier
            {
                Name  = name.Value,
                IsImporter = (bool)is_importer
            };

            context.Suppliers.Add(supplier);
        }

        private static void ImportParts(CarDealerContext context)
        {
            XDocument xml = XDocument.Load(PartsPath);
            var parts = xml.XPathSelectElements("parts/part");
            Random rnd = new Random();

            foreach (var part in parts)
            {
                ImportPart(part, context, rnd);
            }
            context.SaveChanges();
        }

        private static void ImportPart(XElement partNode, CarDealerContext context, Random rnd)
        {
            var name = partNode.Attribute("name");
            var price = (double) partNode.Attribute("price");
            var quantity = (int) partNode.Attribute("quantity");

            int supplierId = rnd.Next(1, context.Suppliers.Count() + 1);

            Part part = new Part
            {
                Name = name.Value,
                Price = price,
                Quantity = quantity,
                Supplier = context.Suppliers.FirstOrDefault(sup => sup.Id == supplierId)
            };

            context.Parts.Add(part);
        }

        private static void ImportCars(CarDealerContext context)
        {
            XDocument xml = XDocument.Load(CarsPath);
            var cars = xml.XPathSelectElements("cars/car");
            Random rnd = new Random();

            foreach (var carNode in cars)
            {
                ImportCars(carNode, context,rnd);   
            }
            context.SaveChanges();
        }

        private static void ImportCars(XElement carNode, CarDealerContext context, Random rnd)
        {
            var make = carNode.Element("make");
            var model = carNode.Element("model");
            var travelledDistance = (double) carNode.Element("travelled-distance");

            int numberOfPartsToAdd = rnd.Next(10, 21);

            List<Part> parts = new List<Part>();
            for (int i = 0; i < numberOfPartsToAdd; i++)
            {
                int randomPartId = rnd.Next(1, context.Parts.Count() + 1);
                parts.Add(context.Parts.FirstOrDefault(part => part.Id == randomPartId));
            }

            Car car = new Car
            {
                Make = make.Value,
                Model = model.Value,
                TravelledDistance = travelledDistance,
                Parts = parts
            };

            context.Cars.Add(car);
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            XDocument xml = XDocument.Load(CustomersPath);
            var customers = xml.XPathSelectElements("customers/customer");

            foreach (var customerNode in customers)
            {
                ImportCustomer(customerNode, context);
            }
            context.SaveChanges();
        }

        private static void ImportCustomer(XElement customerNode, CarDealerContext context)
        {
            var name = customerNode.Attribute("name");
            var birthDate = (DateTime) customerNode.Element("birth-date");
            var isYoungDriver = (bool) customerNode.Element("is-young-driver");

            Customer customer = new Customer
            {
                Name = name.Value,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };

            context.Customers.Add(customer);
        }

        private static void ImportSalesRecords(CarDealerContext context)
        {
            Random rnd = new Random();
            List<decimal> discounts = new List<decimal> {0, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m};
            foreach (var car in context.Cars)
            {
                int randomCustomerId = rnd.Next(1, context.Customers.Count() + 1);
                var sale = new Sale
                {
                    Customer = context.Customers.FirstOrDefault(cust => cust.Id == randomCustomerId),
                    Discount = discounts[rnd.Next(0, discounts.Count)],
                    Car = car
                };
                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }
    }
}