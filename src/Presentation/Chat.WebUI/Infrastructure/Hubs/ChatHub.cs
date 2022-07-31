using System.Security.Claims;
using Chat.Application.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Infrastructure.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private string GetConnectionId() => Context.ConnectionId;
    private string CurrentUserId => Context.User.GetCurrentUserId<string>();

    public async Task SendToAll(string message)
    {
        await Clients.All.SendAsync("SendToAll", message);
    }

    public async Task SendToClient(string userId, string message)
    {
        await Clients.User(userId).SendAsync("SendMessage", message);
    }
    
    public async Task Join(string userId, string message)
    {
        var d =  Clients.User(userId);//..User(userId).SendAsync("SendMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.Others.SendAsync("UserJoined");
    }
}