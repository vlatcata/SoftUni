using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbcontext = new CarDealerContext();

            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();

            string carsJson = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\CarDealershipDB\CarDealer\Datasets\cars.json");
            string customersJson = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\CarDealershipDB\CarDealer\Datasets\customers.json");
            string partsJson = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\CarDealershipDB\CarDealer\Datasets\parts.json");
            string salesJson = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\CarDealershipDB\CarDealer\Datasets\sales.json");
            string suppliersJson = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\CarDealershipDB\CarDealer\Datasets\suppliers.json");


            //Console.WriteLine(ImportSuppliers(dbcontext, suppliersJson));
            //Console.WriteLine(ImportParts(dbcontext, partsJson));
            //Console.WriteLine(ImportCars(dbcontext, carsJson));
            //Console.WriteLine(ImportCustomers(dbcontext, customersJson));
            //Console.WriteLine(ImportSales(dbcontext, salesJson));


            //Console.WriteLine(GetOrderedCustomers(dbcontext));
            //Console.WriteLine(GetCarsFromMakeToyota(dbcontext));
            //Console.WriteLine(GetLocalSuppliers(dbcontext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbcontext));
            //Console.WriteLine(GetTotalSalesByCustomer(dbcontext));
            Console.WriteLine(GetSalesWithAppliedDiscount(dbcontext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
            var suppliers = context.Suppliers.Select(s => s.Id);
            parts = parts.Where(p => suppliers.Any(s => s == p.SupplierId)).ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);
            List<Car> listOfcars = new List<Car>();
            foreach (var carJson in cars)
            {
                Car car = new Car()
                {
                    Make = carJson.Make,
                    Model = carJson.Model,
                    TravelledDistance = carJson.TravelledDistance
                };
                foreach (var partId in carJson.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                listOfcars.Add(car);
            }
            context.Cars.AddRange(listOfcars);
            context.SaveChanges();

            return $"Successfully imported {listOfcars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }


        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd/MM/yyyy";
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(customers, jsonSettings);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(cars, jsonSettings);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(suppliers, jsonSettings);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                        .ToList()
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(cars, jsonSettings);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(customers, jsonSettings);

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("f2"),
                    priceWithDiscount = ((100 - s.Discount) / 100 * s.Car.PartCars.Sum(p => p.Part.Price)).ToString("f2")
                })
                .Take(10)
                .ToList();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var result = JsonConvert.SerializeObject(sales, jsonSettings);

            return result;
        }
    }
}