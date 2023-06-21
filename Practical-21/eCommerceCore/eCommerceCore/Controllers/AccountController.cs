using eCommerceCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCommerceCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }
                    await signInManager.SignInAsync(user,isPersistent: false);
                    return RedirectToAction("Index", "Home");
                   
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string resultUrl = null )
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if (resultUrl == null || resultUrl == "/")
                    {
                        var user = await userManager.FindByEmailAsync(model.Email);
                        var roles = await userManager.GetRolesAsync(user);
                        if(roles.Contains("Admin"))
                        {
                            return RedirectToAction("ListRoles", "Administration");
                        }else if (roles.Contains("User"))
                        {
                            return RedirectToAction("Index", "Product");
                        }
                        else
                        {
                            return RedirectToPage(resultUrl);
                        }
                       
                      
                    }
                    else
                    {
                        return RedirectToPage("Index");
                    }

                }
                ModelState.AddModelError("", "Email or Password Incorrect");
            }
            return View();
        }


    }
}
