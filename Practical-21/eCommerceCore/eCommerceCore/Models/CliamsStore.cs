using System.Security.Claims;

namespace eCommerceCore.Models
{
    
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role")  ,
            new Claim("Create Product", "Create Product"),
            new Claim("Edit Product","Edit Product"),
            new Claim("Delete Product","Delete Product")
        };
    }
}
