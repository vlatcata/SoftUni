using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(Request request, ICartService _cartService) : base(request)
        {
            cartService = _cartService;
        }

        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);

            return View(new 
            {
                Products = products,
                IsAuthenticated = true
            });
        }

        public Response AddProduct(string productId)
        {
            var products = cartService.AddProduct(productId, User.Id);

            return View(new
            {
                Products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        public Response Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }
    }
}
