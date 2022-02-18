using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(Request request, IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return View(new { IsAuthenticated = true });
            }

            return View(new { IsAuthenticated = false });
        }
    }
}
