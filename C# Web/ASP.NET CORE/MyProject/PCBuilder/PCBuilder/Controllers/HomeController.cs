using Microsoft.AspNetCore.Mvc;
using PCBuilder.Core.Constants;
using PCBuilder.Core.Contracts;
using PCBuilder.Core.Models.Cart;
using PCBuilder.Models;
using System.Diagnostics;

namespace PCBuilder.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICartService cartService;

        public HomeController(ILogger<HomeController> logger, ICartService _cartService)
        {
            _logger = logger;
            cartService = _cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cpus()
        {
            var components = cartService.GetAllComponents("CPU");

            return View("AllComponents", components);
        }

        public IActionResult Gpus()
        {
            var components = cartService.GetAllComponents("GPU");

            return View("AllComponents", components);
        }

        public IActionResult Ram()
        {
            var components = cartService.GetAllComponents("RAM");

            return View("AllComponents", components);
        }

        public IActionResult Motherboards()
        {
            var components = cartService.GetAllComponents("Motherboard");

            return View("AllComponents", components);
        }

        public IActionResult Cases()
        {
            var components = cartService.GetAllComponents("Case");

            return View("AllComponents", components);
        }

        public IActionResult PowerSupplies()
        {
            var components = cartService.GetAllComponents("Powersupply");

            return View("AllComponents", components);
        }

        public IActionResult Storage()
        {
            var components = cartService.GetAllComponents("SSD");

            return View("AllComponents", components);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}