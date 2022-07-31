using Chat.Application.Common.Extensions;
using Chat.Application.Common.Interfaces.Users;
using Microsoft.AspNetCore.Http;

namespace Chat.Service.Users;

public class CurrentUserService : ICurrentUserService
{
    public string CurrentUserId { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var principal = httpContextAccessor?.HttpContext?.User;
        CurrentUserId = principal.GetCurrentUserId<string>();
    }
}