using Chat.Application.Common.Models;
using Chat.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Chat.Application.Features.Account.Commands.Login;

public class LoginCommand : IRequest<Result>
{
    public string EmailOrUserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.EmailOrUserName) ?? await _userManager.FindByNameAsync(request.EmailOrUserName);

        if (user is null) return Result.Failure("User not found.");
        
        await _signInManager.SignOutAsync();
        var signInResult = await _signInManager
            .PasswordSignInAsync(user, request.Password, isPersistent: request.RememberMe, lockoutOnFailure:false);
        
        return signInResult.Succeeded ? Result.Success() : Result.Failure("Username/email or password is incorrect.");
    }
};