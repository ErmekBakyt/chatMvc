using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

public class ChatMessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}