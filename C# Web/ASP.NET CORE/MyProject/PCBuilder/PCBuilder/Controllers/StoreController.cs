using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    public class StoreController : BaseController
    {
        public IActionResult Store()
        {
            return View();
        }
    }
}
