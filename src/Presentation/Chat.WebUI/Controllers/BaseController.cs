using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

public class BaseController : Controller
{
   private INotyfService _notyfService;
   private IMediator _mediator;
   
   private INotyfService Notyf => _notyfService ??= HttpContext.RequestServices.GetService<INotyfService>();
   protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

   protected void NotyfError(string message)
   {
      Notyf.Error(message.Replace("'","\\'"));
   }
   
   protected void NotyfError(string[] messages)
   {
      foreach (var message in messages)
      {
         Notyf.Error(message.Replace("'","\\'"));
      }
   }
   
   protected void NotyfSuccess(string message)
   {
      Notyf.Success(message.Replace("'","\\'"));
   }

}