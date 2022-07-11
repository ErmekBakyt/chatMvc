using Chat.Application.Common.Models;
using Chat.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Chat.Application.Features.Account.Commands.Register;

public class RegisterCommand : IRequest<Result>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}


public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var appUser = new AppUser
        {
            UserName = request.UserName,
            Email = request.Email
        };
        var identityResult = await _userManager.CreateAsync(appUser, request.Password);
        if (identityResult.Succeeded) return Result.Success();

        var errorList = identityResult.Errors.Select(error => error.Description).ToList();
        return Result.Failure(errorList);
    }
};