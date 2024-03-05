using System.Security.Claims;

namespace Heartify.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string Id(this ClaimsPrincipal user) 
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
