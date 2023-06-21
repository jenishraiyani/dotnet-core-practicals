using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Practical17.Interfaces;
using Practical17.Models;
using System.Security.Claims;
using Practical17.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Practical17.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users users)
        {
            var userCheck = _userService.GetAllUsers().FirstOrDefault(u => u.Email == users.Email);
            if(userCheck == null)
            {
                var roles = _roleService.GetRoleById(2);
                users.RoleId = roles.Id;
                if (ModelState.IsValid)
                {
                    _userService.AddUser(users);
                    return RedirectToAction("Login", "User");
                }
            }
            ModelState.AddModelError("", "User aleready exits, please register with different email.");
            return View(users);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserDto users)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAllUsers().FirstOrDefault(x => x.Email == users.Email && x.Password == users.Password);
                if(user != null)
                {
                    var role = _roleService.GetRoleById(user.RoleId);

                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Role, role.Name),
                    };
                     
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());

                    return RedirectToAction("Index", "Student");
                }
                ModelState.AddModelError(" ","Invalid Credentials");
                return View();
            }
            return View(users);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

    }
}
