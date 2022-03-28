﻿using Microsoft.AspNetCore.Authorization;
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
            //var model = cartService.GetAllComponents();

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

            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> DetailsComponent(string id)
        {
            var component = await cartService.GetComponent(id);

            return View(component);
        }

        public async Task<IActionResult> EditComponent(string id)
        {
            var component = await cartService.GetComponent(id);

            return View(component);
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        [HttpPost]
        public async Task<IActionResult> EditComponent(AddComponentViewModel viewModel)
        {
            if (await cartService.EditComponent(viewModel))
            {
                ViewData[MessageConstant.SuccessMessage] = "Component Information was updated";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Component Information was not updated";
            }

            return Redirect("/Home/Index");
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> RemoveComponent(Guid id)
        {
            if (await cartService.RemoveComponent(id))
            {
                ViewData[MessageConstant.SuccessMessage] = "Component was deleted";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Component was not deleted";
            }

            return Redirect("/Home/Index");
        }

        public IActionResult ReplaceComponent()
        {
            return RedirectToAction("/Components/{CategoryName}");
        }
    }
}
