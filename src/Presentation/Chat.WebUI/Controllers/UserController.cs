using Chat.Application.Features.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers
{
    public class UserController : BaseController
    {
        public async Task<IActionResult> SearchUsers(string userNameOrEmail)
        {
            var appUser = await Mediator.Send(new SearchUsersQuery(userNameOrEmail));
            return Ok(appUser);
        }
    }
}
