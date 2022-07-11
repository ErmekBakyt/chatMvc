using FluentValidation;

namespace Chat.Application.Features.Account.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(v => v.EmailOrUserName)
            .NotEmpty().WithMessage("Username or email cannot be empty.")
            .NotNull().WithMessage("Username or email cannot be empty.")
            .MaximumLength(100).WithMessage("Username or email length cannot be more than 100");
        RuleFor(v=>v.Password)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .NotNull().WithMessage("Password cannot be empty.")
            .MaximumLength(100).WithMessage("length cannot be more than 100");
            
    }
}