using System.Linq;
using System.Security.Claims;

namespace RecipeBook.Data.Identity
{
    public static class IdentityExtension
    {
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.FirstOrDefault(claim => claim.Type == "FirstName");
            return firstName?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var lastName = principal.Claims.FirstOrDefault(claim => claim.Type == "LastName");
            return lastName?.Value;
        }
    }
}
