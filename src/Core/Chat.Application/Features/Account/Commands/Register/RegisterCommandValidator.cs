using FluentValidation;

namespace Chat.Application.Features.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.UserName).NotEmpty().NotNull().WithMessage("UserName cannot be empty.");
        RuleFor(v => v.UserName).NotEmpty().NotNull().WithMessage("Password cannot be empty.");
    }
}