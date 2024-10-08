﻿using static Heartify.Infrastructure.Data.Constants.AdministratorConstants;

namespace System.Security.Claims
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
