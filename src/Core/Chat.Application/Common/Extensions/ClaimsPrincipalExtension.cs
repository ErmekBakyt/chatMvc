using System.Security.Claims;

namespace Chat.Application.Common.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string GetCurrentUserId<T>(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        return loggedInUserId;
    }
}