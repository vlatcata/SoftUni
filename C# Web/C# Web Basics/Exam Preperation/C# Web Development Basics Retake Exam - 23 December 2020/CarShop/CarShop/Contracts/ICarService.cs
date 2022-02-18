using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        (bool isCreated, string error) Create(AddCarViewModel model, string userId);
        IEnumerable<AllCarsViewModel> GetAllCars(string userId);

        bool UserIsMechanic(string userId);

        bool UserOwnsCar(string userId, string carId);
    }
}
