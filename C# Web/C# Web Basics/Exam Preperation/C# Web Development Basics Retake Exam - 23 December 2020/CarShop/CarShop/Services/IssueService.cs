using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly ICarService carService;
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public IssueService(IValidationService _validationService, IRepository _repo, ICarService _carService)
        {
            validationService = _validationService;
            repo = _repo;
            carService = _carService;
        }

        public object GetCarIssues(string userId, string carId)
        {
            return repo.All<Car>()
                 .Where(c => c.Id == carId)
                 .Select(c => new CarIssuesViewModel()
                 {
                     Id = c.Id,
                     Model = c.Model,
                     Year = c.Year,
                     UserIsMechanic = carService.UserIsMechanic(userId),
                     Issues = c.Issues.Select(i => new IssueListingViewModel()
                     {
                         Id = i.Id,
                         Description = i.Description,
                         IsFixed = i.IsFixed,
                         IsFixedInformation = i.IsFixed ? "Yes" : "Not yet"
                     })
                 })
                 .FirstOrDefault();
        }

        public bool UserCanAccessCar(string userId, string carId)
        {
            var isUserMechanic = carService.UserIsMechanic(userId);

            if (!isUserMechanic)
            {
                var userOwnCar = carService.UserOwnsCar(userId, carId);

                if (!userOwnCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
