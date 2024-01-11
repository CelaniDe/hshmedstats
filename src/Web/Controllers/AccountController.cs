using hshmedstats.Application.Logging;
using hshmedstats.Domain;
using hshmedstats.Web.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hshmedstats.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _SignInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewData["ReturnUrl"] = returnUrl;

            // Clear to ensure clean login process
            await HttpContext.SignOutAsync();

            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    Logger.LogInformation(string.Format("User {0} logged in", model.Username));

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Dashboard", null);
                }

                ModelState.AddModelError("Password", "Invalid Login attemt.");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            
            return RedirectToAction("Login");
        }
    }
}
