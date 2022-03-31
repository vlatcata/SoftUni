using Microsoft.EntityFrameworkCore;
using PcBuilder.Infrastructure.Data.Repositories;
using PCBuilder.Core.Contracts;
using PCBuilder.Core.Models.Cart;
using PCBuilder.Core.Models.Home;
using PCBuilder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IApplicationDbRepository repo;

        public ComputerService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> BuildComputer(CartViewModel model)
        {
            var result = false;

            var components = await repo.All<CartComponent>()
                .Where(c => c.CartId == model.CartId)
                .Select(c => c.Component)
                .ToListAsync();

            var computer = new Computer()
            {
                UserId = model.UserId,
                Components = components
            };

            if (computer.Components.Count < 7)
            {
                return false;
            }

            try
            {
                await repo.AddAsync(computer);
                await repo.SaveChangesAsync();

                result = true;
            }
            catch (InvalidOperationException ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<List<ComputerViewModel>> GetUserComputers(string userId)
        {
            var computers = await repo.All<Computer>()
                .Where(c => c.UserId == userId)
                .Include(c => c.Components)
                .Select(c => new ComputerViewModel()
                {
                    UserId=userId,
                    Components = c.Components.Select(c => new AddComponentViewModel()
                    {
                        Category = c.Category.ToString(),
                        Id = c.Id,
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
                    .ToList()
                })
                .ToListAsync();

            return computers;
        }
    }
}
