using Chat.Application.Common.Interfaces.Infrastructure;
using Chat.Application.Common.Models;
using Chat.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

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
    private readonly IConfiguration _configuration;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager, ISenderEmailService emailService, LinkGenerator linkGenerator, IConfiguration configuration)
    {
        _userManager = userManager;
        _linkGenerator = linkGenerator;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<Result> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null) return Result.Failure("User not found");
        var resetTokenAsync=  await _userManager.GeneratePasswordResetTokenAsync(user);
        var url = _linkGenerator.GetPathByAction("ResetPassword", "Account", new
        {
            userId = user.Id,
            token = resetTokenAsync
        });
        var dd = _configuration["BaseUrl"];
        var fullPath = $"{_configuration["BaseUrl"]}{url}"; 
        var result = await _emailService.SendEmailAsync(new EmailMessage(new[] { user.Email }, "Reset password", fullPath));
        return result.Succeed ? Result.Success() : Result.Failure(result.Message);
    }
}