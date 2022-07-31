namespace Chat.Application.Common.Interfaces.Users;

public interface ICurrentUserService
{
    public string CurrentUserId { get; }
}