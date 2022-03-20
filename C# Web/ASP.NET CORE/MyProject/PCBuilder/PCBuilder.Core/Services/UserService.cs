using Microsoft.EntityFrameworkCore;
using PcBuilder.Infrastructure.Data.Repositories;
using PCBuilder.Core.Contracts;
using PCBuilder.Core.Models;
using PCBuilder.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserListViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();
        }
    }
}
