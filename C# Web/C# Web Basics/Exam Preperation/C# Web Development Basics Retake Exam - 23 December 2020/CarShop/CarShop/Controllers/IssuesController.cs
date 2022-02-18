using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly ICarService carService;
        public IssuesController(Request request, IIssueService _issueService, ICarService _carService) : base(request)
        {
            issueService = _issueService;
            carService = _carService;
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            if (!issueService.UserCanAccessCar(User.Id, carId))
            {
                return Unauthorized();
            }

            var carIssues = issueService.GetCarIssues(User.Id, carId);

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public Response Add(string carId)
        {
            return View();
        }
    }
}
