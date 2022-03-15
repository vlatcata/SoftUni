using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Infrastructure.Common;

namespace PCBuilder.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        public CartController()
        {
            
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult AddComponent()
        {
            return View();
        }

        public IActionResult DetailsComponent()
        {
            return View();
        }

        public IActionResult ReplaceComponent()
        {
            return RedirectToAction("/Components/{CategoryName}");
        }
    }
}
