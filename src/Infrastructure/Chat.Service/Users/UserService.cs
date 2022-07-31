using System.Globalization;
using Chat.Application.Common.Interfaces.Users;
using Chat.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chat.Service.Users;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<AppUser>> SearchUsersAsync(string userNameOrEmail)
    {
        return await _userManager.Users
            .Where(x => x.UserName.Contains(userNameOrEmail) || x.Email.Contains(userNameOrEmail))
            .ToListAsync();
    }
}