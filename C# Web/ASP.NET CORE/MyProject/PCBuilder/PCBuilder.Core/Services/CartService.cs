using PcBuilder.Infrastructure.Data.Repositories;
using PCBuilder.Core.Contracts;
using PCBuilder.Core.Models.Cart;
using PCBuilder.Infrastructure.Data;
using PCBuilder.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IApplicationDbRepository repo;

        public CartService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> CreateComponent(AddComponentViewModel model)
        {
            bool result = false;

            var category = new Category()
            {
                Name = model.Category
            };

            var component = new Component()
            {
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Category = category,
                CategoryId = category.Id
            };

            var specifications = model.Specifications.Select(s => new Specification()
            {
                Component = component,
                Title = s.Name,
                Description = s.Description
            })
                .ToList();

            component.Specifications = specifications;

            try
            {
                await repo.AddAsync(component);
                await repo.SaveChangesAsync();

                result = true;
            }
            catch (InvalidOperationException ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<AddComponentViewModel> GenerateDefaultModel()
        {
            var specifications = new List<SpecificationsViewModel>();

            specifications.Add(new SpecificationsViewModel()
            {
                Name = "threads",
                Description = "14"
            });
            specifications.Add(new SpecificationsViewModel()
            {
                Name = "speed",
                Description = "4.5Ghz"
            });

            var component = new AddComponentViewModel()
            {
                Category = CategoryName.CPU,
                ImageUrl = "https://s13emagst.akamaized.net/products/23377/23376646/images/res_f05cd8bec1059f12f285f0110a76088f.jpg",
                Manufacturer = "Intel",
                Model = "Core I7",
                Price = 500,
                Specifications = specifications
            };

            return component;
        }
    }
}
