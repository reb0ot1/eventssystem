using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Models.Users;
using WebDevCore.ViewModels.AccountVM;

namespace WebDevCore.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<EventureUser> signIn;

        public AccountController(SignInManager<EventureUser> signIn)
        {
            this.signIn = signIn;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == viewModel.Username);
            if (user == null)
            {
                return View();
            }
            var test = this.signIn.UserManager.CheckPasswordAsync(user, viewModel.Password);

            if (test.Result)
            {
                this.signIn.SignInAsync(user, viewModel.RememberMe).Wait();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new EventureUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = this.signIn.UserManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                this.signIn.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.signIn.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
