using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("SendMessage", message);
    }
}