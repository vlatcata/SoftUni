using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Castle.Core.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Db was created!");


            //string users = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\ProductShopDB\ProductShop\Datasets\users.json");

            //string products = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\ProductShopDB\ProductShop\Datasets\products.json");

            //string categoriesProducts = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\ProductShopDB\ProductShop\Datasets\categories-products.json");

            //string categories = File.ReadAllText(@"C:\Programming\SoftUni\C# DB\Entity Framework Core\JSON Processing\ProductShopDB\ProductShop\Datasets\categories.json");


            //Console.WriteLine(ImportUsers(dbContext, users));
            //Console.WriteLine(ImportProducts(dbContext, products));
            //Console.WriteLine(ImportCategories(dbContext, categories));
            //Console.WriteLine(ImportCategoryProducts(dbContext, categoriesProducts));


            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            int count = users.Count;
            context.SaveChanges();
            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            int count = products.Count;
            context.SaveChanges();
            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson).Where(x => !x.Name.IsNullOrEmpty());
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            context.CategoryProducts.AddRange(categoryProducts);
            int count = categoryProducts.Count;
            context.SaveChanges();
            return $"Successfully imported {count}";
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var productsToExport = JsonConvert.SerializeObject(products, jsonSettings);

            return productsToExport;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
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
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var usersToExport = JsonConvert.SerializeObject(users, jsonSettings);

            return usersToExport;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var categoriesToExport = JsonConvert.SerializeObject(categories, jsonSettings);

            return categoriesToExport;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .ToList()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var usersToPrint = new
            {
                UsersCount = users.Count,
                Users = users
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var result = JsonConvert.SerializeObject(usersToPrint, jsonSettings);

            return result;
        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });
            IMapper mapper = new Mapper(mapperConfiguration);
        }
    }
}