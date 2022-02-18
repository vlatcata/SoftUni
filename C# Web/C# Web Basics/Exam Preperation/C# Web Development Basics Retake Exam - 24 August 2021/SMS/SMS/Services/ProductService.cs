using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models.Product;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public ProductService(IRepository _repo, IValidationService _validationService)
        {
            validationService = _validationService;
            repo = _repo;
        }

        public (bool isCreated, string error) CreateProduct(CreateProductViewModel model)
        {
            bool isCreated = false;
            string error = null;

            var (isValid, errorMsg) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMsg);
            }

            decimal price;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05M || price > 1000M)
            {
                return (false, "Price must be between 0.05 and 1000");
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                error = "Could not create product";
            }

            return (isCreated, error);
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(x => new ProductListViewModel()
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2"),
                    ProductId = x.Id
                })
                .ToList();
        }
    }
}
