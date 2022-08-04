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
        var commonChatListId = chatMessage.CommonChatListId;

        if (string.IsNullOrEmpty(commonChatListId) || Guid.Parse(commonChatListId) == Guid.Empty)
        {
            commonChatListId = await Mediator.Send(new CheckChatListExistenceQuery(chatMessage.FromUserId, chatMessage.ToUserId));
            if (string.IsNullOrEmpty(commonChatListId))
            {
                (_,commonChatListId) = await Mediator.Send(new CreateChatListCommand
                {
                    FromUserId = currentUserId,
                    ToUserId = chatMessage.ToUserId
                });
            }
        }

        await Mediator.Send(new CreateMessageCommand
        {
            TextMessage = chatMessage.TextMessage,
            FromUserId = currentUserId,
            ToUserId = chatMessage.ToUserId,
            CommonChatListId = commonChatListId
        });
        // await ChatService.SendMessage(chatMessage.TextMessage, chatMessage.ToUserId.ToString());
        return Ok();
    }

    [HttpGet("Chat/GetUserChatMessages/{chatListId}")]
    public async Task<IActionResult> GetUserChatMessages(string chatListId)
    {
        var chatList = await Mediator.Send(new GetUserChatMessagesQuery(chatListId));
        return Ok(chatList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}