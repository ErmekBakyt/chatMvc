using AspNetCoreHero.ToastNotification.Helpers;
using Chat.Application.Features.Account.Commands.ForgotPassword;
using Chat.Application.Features.Account.Commands.Login;
using Chat.Application.Features.Account.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

public class AccountController : BaseController
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        if (ModelState.IsValid)
        {
            var result = await Mediator.Send(command);
            if(!result.Succeed)
                foreach (var message in result.Message) NotyfError(message);
            else
                NotyfSuccess("User created successfully!");
        }

        return View();
    }
    
    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        TempData["returnUrl"] = returnUrl;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        if (ModelState.IsValid)
        {
            var result = await Mediator.Send(command);
            if (!result.Succeed) NotyfError(result.Message);

            return TempData["returnUrl"] is not null ? Redirect(TempData["returnUrl"].ToString() ?? "Home/Index") 
                : RedirectToAction("Index", "Chat");
        }
        return View(command);
    }

    [HttpGet]
    public async Task<IActionResult> ForgotPassword()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
    {
        if (!ModelState.IsValid) return View();
        
        var result = await Mediator.Send(command);
        
        if (!result.Succeed) NotyfError(@"Server error try again please");
        else  NotyfSuccess("Message successfully sent");
        
        return View(command);
    }

    [HttpGet]
    public async Task<IActionResult> ResetPassword(string userId, string token)
    {
        TempData["userId"] = userId;
        TempData["token"] = token;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordConfirmCommand command)
    {
        if (!ModelState.IsValid) return View();

        command.Token = TempData["token"]?.ToString();
        command.UserId = TempData["userId"]?.ToString();
        
        var result = await Mediator.Send(command);
        
        if (result.Succeed)  NotyfSuccess("Successfully updated");
        else NotyfError(result.Message);
        
        return View(command);
    }
}