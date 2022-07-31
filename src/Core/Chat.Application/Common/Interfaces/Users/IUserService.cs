using Chat.Core.Identity;

namespace Chat.Application.Common.Interfaces.Users;

public interface IUserService
{
    Task<List<AppUser>> SearchUsersAsync(string userNameOrEmail);
}