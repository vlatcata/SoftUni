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
    public class CarService : ICarService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public CarService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isCreated, string error) Create(AddCarViewModel model, string userId)
        {
            bool isCreated = false;
            string error = null;

            var (isValid, errorMsg) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMsg);
            }

            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = userId
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                error = "Could not create car";
            }

            return (isCreated, error);

        }

        public IEnumerable<AllCarsViewModel> GetAllCars(string userId)
        {
            List<AllCarsViewModel> cars;

            if (UserIsMechanic(userId))
            {
                cars = repo.All<Car>()
                    .Where(c => c.Issues.Any(i => !i.IsFixed))
                    .Select(c => new AllCarsViewModel()
                    {
                        Id = c.Id,
                        Model = c.Model,
                        Image = c.PictureUrl,
                        Year = c.Year,
                        Plate = c.PlateNumber,
                        FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                        RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count()
                    })
                    .ToList();
            }
            else
            {
                cars = repo.All<Car>()
                    .Where(c => c.OwnerId == userId)
                    .Select(c => new AllCarsViewModel()
                    {
                        Id = c.Id,
                        Model = c.Model,
                        Image = c.PictureUrl,
                        Year = c.Year,
                        Plate = c.PlateNumber,
                        FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                        RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count()
                    })
                    .ToList();
            }

            return cars;
        }

        public bool UserIsMechanic(string userId)
        {
            return repo.All<User>()
                .Any(u => u.IsMechanic && u.Id == userId);
        }

        public bool UserOwnsCar(string userId, string carId)
        {
            return repo.All<Car>()
                .Any(c => c.Id == carId && c.OwnerId == userId);
        }
    }
}
