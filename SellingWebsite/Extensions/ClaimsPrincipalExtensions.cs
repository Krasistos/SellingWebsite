using System.Security.Claims;
using static SellingWebsite.Core.Constants.AdministratorConstants;

public static class ClaimsPrincipalExtensions
{
    public static string Id(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user != null &&
               user.Identity != null &&
               user.Identity.IsAuthenticated &&
               user.IsInRole(AdminRole);
    }

}