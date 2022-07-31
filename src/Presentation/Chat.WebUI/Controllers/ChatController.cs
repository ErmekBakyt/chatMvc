using Chat.Application.Common.DTOs;
using Chat.Application.Features.Messages.Commands;
using Chat.Application.Features.Messages.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

[Authorize]
public class ChatController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto chatMessage)
    {
        
        
        var currentUserId = CurrentUser.CurrentUserId;

        await Mediator.Send(new GetUserChatListQuery());
        
        // await Mediator.Send(new CreateMessageCommand
        // {
        //     TextMessage = chatMessage.TextMessage,
        //     FromUserId = new Guid(currentUserId),
        //     ToUserId = chatMessage.ToUserId,
        // });
        // await ChatService.SendMessage(chatMessage.TextMessage, chatMessage.ToUserId.ToString());
        return Ok();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}