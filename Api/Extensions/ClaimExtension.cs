using System.Security.Claims;

namespace Api.Extensions
{
    public static class ClaimExtension
    {
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.GivenName)?.Value;
        }
    }
}
