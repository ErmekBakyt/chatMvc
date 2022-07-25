using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Hubs;

public class ChatHub : Hub
{
    public void SendMessage(string message)
    {
        Clients.All.SendAsync(message);
    }
}