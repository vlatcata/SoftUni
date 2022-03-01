using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService _userService) : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { ErrorMessage = "Incorrect Login" }, "/Error");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/Players/All");
        }

        public Response Register()
        {
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isRegistered, error) = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Login");
            }

            return View(new { ErrorMessage = error }, "/Error");
        }

        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
