using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Register()
    {
        return View();
    }
}