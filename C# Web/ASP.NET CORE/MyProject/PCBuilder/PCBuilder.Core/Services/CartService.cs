using Microsoft.EntityFrameworkCore;
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
                CategoryId = category.Id,
                Specifications = model.Specifications.Select(s => new Specification()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description
                })
                .ToList()
            };

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

        public async Task<AddComponentViewModel> GetComponent(string id)
        {
            var component = await repo.All<Component>()
                .Where(c => c.Id.ToString() == id)
                .Include(c => c.Category)
                .Select(c => new AddComponentViewModel()
                {
                    Id = c.Id,
                    Category = c.Category.Name,
                    ImageUrl = c.ImageUrl,
                    Manufacturer = c.Manufacturer,
                    Model = c.Model,
                    Price = c.Price,
                    Specifications = c.Specifications.Select(s => new SpecificationsViewModel()
                    {
                        Id = s.Id,
                        Description = s.Description,
                        Title = s.Title
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();

            return component;
        }

        public async Task<AddComponentViewModel> GenerateDefaultModel()
        {
            var specifications = new List<SpecificationsViewModel>();

            specifications.Add(new SpecificationsViewModel()
            {
                Id = Guid.NewGuid(),
                Title = "threads",
                Description = "14"
            });
            specifications.Add(new SpecificationsViewModel()
            {
                Id = Guid.NewGuid(),
                Title = "speed",
                Description = "4.5Ghz"
            });
            specifications.Add(new SpecificationsViewModel()
            {
                Id = Guid.NewGuid(),
                Title = "speasdasdaded",
                Description = "4.5Gsssshz"
            });

            var component = new AddComponentViewModel()
            {
                Category = "CPU",
                ImageUrl = "https://s13emagst.akamaized.net/products/23377/23376646/images/res_f05cd8bec1059f12f285f0110a76088f.jpg",
                Manufacturer = "Intel",
                Model = "Core I7",
                Price = 500,
                Specifications = specifications
            };

            return component;
        }

        public async Task<List<AddComponentViewModel>> GetAllComponents(string name)
        {
            var components = await repo.All<Component>()
                .Where(c => c.Category.Name == name)
                .Select(c => new AddComponentViewModel()
                {
                    Id = c.Id,
                    Category = c.Category.Name,
                    ImageUrl = c.ImageUrl,
                    Manufacturer = c.Manufacturer,
                    Model = c.Model,
                    Price = c.Price,
                    Specifications = c.Specifications.Select(s => new SpecificationsViewModel()
                    {
                        Description = s.Description,
                        Id = s.Id,
                        Title = s.Title
                    })
                    .ToList()
                })
                .ToListAsync();

            return components;
        }

        public async Task<bool> EditComponent(AddComponentViewModel model)
        {
            var result = false;

            var specifications = model.Specifications
                .Select(s => new Specification()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description
                })
                .ToList();

            var component = await repo.GetByIdAsync<Component>(model.Id);

            if (component != null)
            {
                component.Model = model.Model;
                component.ImageUrl = model.ImageUrl;
                component.Manufacturer = model.Manufacturer;
                component.Price = model.Price;
                component.Specifications = specifications;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<bool> RemoveComponent(Guid id)
        {
            var result = false;

            var component = await repo.GetByIdAsync<Component>(id);

            if (component != null)
            {
                await repo.DeleteAsync<Component>(id);
                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}
