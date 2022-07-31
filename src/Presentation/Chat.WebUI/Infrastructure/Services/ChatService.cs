using Chat.WebUI.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebUI.Infrastructure.Services;

public class ChatService
{
    private readonly IHubContext<ChatHub> _hubContext;

    public ChatService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(string message, string toUserId)
    {
        await _hubContext.Clients.User(toUserId).SendAsync("ReceiveMessage", message);
    }
}