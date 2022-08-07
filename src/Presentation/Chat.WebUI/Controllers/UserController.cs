using Chat.Application.Common.DTOs;
using Chat.Application.Features.ChatList.Dto;
using Chat.Application.Features.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers
{
    public class UserController : BaseController
    {
        public async Task<IActionResult> SearchUsers(string userNameOrEmail)
        {
            var appUsers = await Mediator.Send(new SearchUsersQuery(userNameOrEmail));
     
                var chatListDto = new ChatListDto
                {
                    UserInfo = new UserInfoDto
                    {
                        FullName = appUsers.FirstOrDefault()?.UserName,
                        UserId = appUsers.FirstOrDefault()?.Id
                    }
                };
            
            return PartialView("Chat/_ChatListPartial",chatListDto);
        }
    }
}
