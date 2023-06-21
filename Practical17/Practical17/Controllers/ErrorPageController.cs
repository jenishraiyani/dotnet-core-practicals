using Microsoft.AspNetCore.Mvc;

namespace Practical17.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("ErrorPage/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["Error"] = "Page Not Found";
                    break;
                case 403:
                    ViewData["Error"] = "Access Denied";
                    break;
                default:
                    break;

            }
            return View("ErrorPage");
        }
    }
}
