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

        public async Task<IActionResult> Cpus()
        {
            var components = await cartService.GetAllComponents("CPU");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> Gpus()
        {
            var components = await cartService.GetAllComponents("GPU");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> Ram()
        {
            var components = await cartService.GetAllComponents("RAM");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> Motherboards()
        {
            var components = await cartService.GetAllComponents("Motherboard");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> Cases()
        {
            var components = await cartService.GetAllComponents("Case");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> PowerSupplies()
        {
            var components = await cartService.GetAllComponents("Power Supply");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
        }

        public async Task<IActionResult> Ssds()
        {
            var components = await cartService.GetAllComponents("SSD");

            if (components != null && components.Count > 0)
            {
                return View("AllComponents", components);
            }

            return View("ErrorCustom");
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

        public IActionResult ErrorCustom()
        {
            return View();
        }
    }
}