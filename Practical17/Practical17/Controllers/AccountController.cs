using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Practical17.Controllers
{
    public class AccountController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
       
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
