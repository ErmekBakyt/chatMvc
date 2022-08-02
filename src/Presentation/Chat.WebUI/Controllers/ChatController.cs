using Chat.Application.Common.DTOs;
using Chat.Application.Features.ChatList.Commands;
using Chat.Application.Features.ChatList.Queries;
using Chat.Application.Features.Messages.Commands;
using Chat.Application.Features.Messages.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

[Authorize]
public class ChatController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var chatList = await Mediator.Send(new GetUserChatListQuery());
        return View(chatList);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto chatMessage)
    {
        var currentUserId = CurrentUser.CurrentUserId;


        // var (_,chatListId) = await Mediator.Send(new CreateChatListCommand
        // {
        //     FromUserId = currentUserId,
        //     ToUserId = chatMessage.ToUserId
        // });

        // await Mediator.Send(new CreateMessageCommand
        // {
        //     TextMessage = chatMessage.TextMessage,
        //     FromUserId = currentUserId,
        //     ToUserId = chatMessage.ToUserId,
        //     ChatListId = "2dd1925f-304f-474c-9bda-b77fa650d3c7"
        // });
        // await ChatService.SendMessage(chatMessage.TextMessage, chatMessage.ToUserId.ToString());
        return Ok();
    }

    [HttpGet("Chat/GetUserChatMessages/{chatListId}")]
    public async Task<IActionResult> GetUserChatMessages(string chatListId)
    {
        var chatList = await Mediator.Send(new GetUserChatMessagesQuery(chatListId));
        return Ok(chatList);
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