using eCommerceCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;

namespace eCommerceCore.Views.Account
{
    
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Model { get; set; }
        public void OnGet()
        {
        }
    }
}
