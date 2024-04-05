using System.Security.Claims;
using static Heartify.Core.Constants.AdministratorConstants;

namespace Heartify.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string Id(this ClaimsPrincipal user) 
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user) 
        {
            return user.IsInRole(AdminRole);
        }
    }
}
