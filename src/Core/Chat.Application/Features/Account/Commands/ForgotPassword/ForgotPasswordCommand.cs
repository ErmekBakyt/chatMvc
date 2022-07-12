using Chat.Application.Common.Interfaces.Infrastructure;
using Chat.Application.Common.Models;
using Chat.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace Chat.Application.Features.Account.Commands.ForgotPassword;

public class ForgotPasswordCommand : IRequest<Result>
{
    public string Email { get; set; }
}

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Result>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ISenderEmailService _emailService;
    private readonly LinkGenerator _linkGenerator;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager, ISenderEmailService emailService, LinkGenerator linkGenerator)
    {
        _userManager = userManager;
        _linkGenerator = linkGenerator;
        _emailService = emailService;
    }

    public async Task<Result> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            var resetTokenAsync=  await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = _linkGenerator.GetPathByAction("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = resetTokenAsync
            });

            var result = await _emailService.SendEmailAsync(new EmailMessage(new[] { user.Email }, "Reset password", url));
            return result.Succeed ? Result.Success() : Result.Failure(result.Message);
        }
        return Result.Failure("User not found");
    }
}