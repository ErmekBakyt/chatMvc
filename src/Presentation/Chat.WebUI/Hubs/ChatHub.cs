using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Hubs;

public class ChatHub : Hub
{
    public async Task SendToAll(string message)
    {
        await Clients.All.SendAsync("SendToAll", message);
    }

    public async Task SendToClient(string userId)
    {
        Clients.User(userId).SendCoreAsync();
    }
}