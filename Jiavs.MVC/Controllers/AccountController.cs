using Jiavs.Application.IServices;
using Jiavs.Infrastructure.DTO;
using Jiavs.Infrastructure.Identity.Models;
using Jiavs.Infrastructure.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

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
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var signResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                    if (signResult.Succeeded)
                    {
                        return SafeLocalRedirect(returnUrl);
                    }
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
                    var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                    _articleUserService.Create(userDto);
                    return SafeLocalRedirect(returnUrl);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToHome();
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
                return RedirectToHome();
            }
        }

        private IActionResult RedirectToHome()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}