using Microsoft.EntityFrameworkCore;
using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {
            repo = _repo;
        }

        public IEnumerable<CartDetailsViewModel> AddProduct(string productId, string userId)
        {
            var product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(u => u.Products)
                .FirstOrDefault();

            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            { }

            return user.Cart.Products
                .Select(p => new CartDetailsViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString()
                });
        }

        public void BuyProducts(string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(u => u.Products)
                .FirstOrDefault();

            user.Cart.Products.Clear();

            repo.SaveChanges();
        }

        public IEnumerable<CartDetailsViewModel> GetProducts(string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(u => u.Products)
                .FirstOrDefault();

            var products = user.Cart.Products
                .Select(u => new CartDetailsViewModel()
                {
                    ProductName = u.Name,
                    ProductPrice = u.Price.ToString("F2")
                });

            return products;
        }
    }
}
