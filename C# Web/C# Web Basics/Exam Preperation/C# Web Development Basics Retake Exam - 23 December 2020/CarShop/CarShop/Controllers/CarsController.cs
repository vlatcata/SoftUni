using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(Request request, ICarService _carService) : base(request)
        {
            carService = _carService;
        }

        [Authorize]
        public Response All()
        {
            var cars = carService.GetAllCars(User.Id);

            return View(cars);
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddCarViewModel model)
        {
            var (created, error) = carService.Create(model, User.Id);

            if (!created)
            {
                return View(new { ErrorMessage = error}, "/Error");
            }

            return View("/Cars/All");
        }
    }
}
