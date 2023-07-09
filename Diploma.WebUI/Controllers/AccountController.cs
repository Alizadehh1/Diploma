using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities.Membership;
using Diploma.WebUI.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DiplomaDbContext db;
        private readonly SignInManager<DiplomaUser> signInManager;
        private readonly UserManager<DiplomaUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IActionContextAccessor ctx;

        public AccountController(DiplomaDbContext db, SignInManager<DiplomaUser> signInManager, UserManager<DiplomaUser> userManager,
            IConfiguration configuration,
            IActionContextAccessor ctx)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.ctx = ctx;
        }
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                DiplomaUser foundedUser = null;

                foundedUser = await userManager.FindByEmailAsync(user.Email);

                if (foundedUser == null)
                {
                    ViewBag.Message = "E-Poçtunuz və ya şifrəniz yanlışdır!";
                    goto end;
                }
                var signInResult = await signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (!signInResult.Succeeded)
                {
                    ViewBag.Message = "E-Poçtunuz və ya şifrəniz yanlışdır!";
                    goto end;
                }

                var callBackUrl = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(callBackUrl))
                {
                    return Redirect(callBackUrl);
                }
                return RedirectToAction("Index", "Home");
            }

        end:
            return View(user);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new DiplomaUser();
                user.Email = model.Email;
                if (db.Users.Any(u => u.Email == model.Email))
                {
                    ViewBag.Message = "Bu email ilə artıq qeydiyyatdan keçmisiniz";
                    goto end;
                }
                user.UserName = model.Email;
                user.PhoneNumberConfirmed = true;
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
        end:
            return View(model);
        }
    }
}
