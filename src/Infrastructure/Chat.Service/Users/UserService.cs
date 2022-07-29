using System.Globalization;
using Chat.Application.Common.Interfaces.Users;
using Chat.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Chat.Service.Users;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AppUser> SearchUserAsync(string userNameOrEmail)
    {
        return await _userManager.FindByNameAsync(userNameOrEmail) ?? await _userManager.FindByEmailAsync(userNameOrEmail);
    }
}