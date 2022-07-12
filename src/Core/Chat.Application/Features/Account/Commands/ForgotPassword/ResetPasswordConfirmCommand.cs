using Chat.Application.Common.Extensions;
using Chat.Application.Common.Models;
using Chat.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Chat.Application.Features.Account.Commands.ForgotPassword;

public class ResetPasswordConfirmCommand : IRequest<Result>
{
    public string NewPassword { get; set; }
    public string UserId { get; set; }
    public string Token { get; set; }
}

public class ResetPasswordConfirmCommandHandler : IRequestHandler<ResetPasswordConfirmCommand, Result>
{
    private readonly UserManager<AppUser> _userManager;

    public ResetPasswordConfirmCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(ResetPasswordConfirmCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null) return Result.Failure("User not found");

        var resetPasswordResult = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!resetPasswordResult.Succeeded) return resetPasswordResult.ToApplicationResult();

        await _userManager.UpdateSecurityStampAsync(user);
        return Result.Success();
    }
}
