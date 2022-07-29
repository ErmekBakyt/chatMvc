using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Infrastructure.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private string GetConnectionId() => Context.ConnectionId;
    public async Task SendToAll(string message)
    {
        await Clients.All.SendAsync("SendToAll", message);
    }

    public async Task SendToClient(string userId, string message)
    {
        await Clients.User(userId).SendAsync("SendMessage", message);
    }
}