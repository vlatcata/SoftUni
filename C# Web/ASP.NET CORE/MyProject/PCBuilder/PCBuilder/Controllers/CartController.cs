using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Core.Constants;
using PCBuilder.Core.Contracts;
using PCBuilder.Core.Models.Cart;
using PCBuilder.Infrastructure.Common;
using PCBuilder.Infrastructure.Data.Identity;

namespace PCBuilder.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IUserService userService;

        public CartController(ICartService _cartService, IUserService _userService)
        {
            userService = _userService;
            cartService = _cartService;
        }

        public IActionResult Cart()
        {
            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> AddComponent()
        {
            var model = await cartService.GenerateDefaultModel();

            return View(model);
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        [HttpPost]
        public async Task<IActionResult> AddComponent(AddComponentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (await cartService.CreateComponent(viewModel))
            {
                ViewData[MessageConstant.SuccessMessage] = "Component was created successfully!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            return RedirectToAction("Cart");
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
