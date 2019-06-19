using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jiavs.Application.IServices;
using Jiavs.Application.Models;
using Jiavs.Infrastructure.Identity.Models;
using Jiavs.Infrastructure.Identity.Models.AccountViewModels;
using Jiavs.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jiavs.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<JiavsUser> _signInManager;
        private readonly UserManager<JiavsUser> _userManager;
        private readonly IArticleUserService _articleUserService;

        public AccountController(SignInManager<JiavsUser> signInManager, UserManager<JiavsUser> userManager, IArticleUserService articleUserService)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._articleUserService = articleUserService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            SetReturnUrl(returnUrl);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            SetReturnUrl(returnUrl);
            if (ModelState.IsValid)
            {
                var signResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (signResult.Succeeded)
                {
                    return SafeLocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "登录失败");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            SetReturnUrl(returnUrl);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            SetReturnUrl(returnUrl);
            if (ModelState.IsValid)
            {
                var user = new JiavsUser { Email = model.Email, UserName = model.UserName };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (createResult.Succeeded)
                {
                    var userDto = new ArticleUserDto()
                    {
                        Id = user.Id,
                        Name = model.UserName,
                        Email = model.Email,
                        RegisterTime = DateTime.UtcNow
                    };
                    _articleUserService.Create(userDto);
                    return SafeLocalRedirect(returnUrl);
                }
            }
            return View(model);
        }

        private void SetReturnUrl(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
        }

        private IActionResult SafeLocalRedirect(string url)
        {
            if (Url.IsLocalUrl(url))
            {
                return LocalRedirect(url);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}