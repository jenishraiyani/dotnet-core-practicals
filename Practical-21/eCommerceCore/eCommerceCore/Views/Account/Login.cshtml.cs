using eCommerceCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eCommerceCore.Views.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Model { get; set; }
        public void OnGet()
        {
        }
    }
}
