using AspNetCoreHero.ToastNotification.Abstractions;
using Chat.Application.Common.Interfaces.Users;
using Chat.WebUI.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebUI.Controllers;

public class BaseController : Controller
{
   private INotyfService _notyfService;
   private IMediator _mediator;
   private ICurrentUserService _currentUserId;
   private ChatService _chatService;
   
   private INotyfService Notyf => _notyfService ??= HttpContext.RequestServices.GetService<INotyfService>();
   protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
   
   protected ICurrentUserService CurrentUser => _currentUserId ??= HttpContext.RequestServices.GetService<ICurrentUserService>();
   protected ChatService ChatService => _chatService ??= HttpContext.RequestServices.GetService<ChatService>();
   

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