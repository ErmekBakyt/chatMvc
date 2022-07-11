using FluentValidation;

namespace Chat.Application.Features.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("UserName cannot be empty.")
            .NotNull().WithMessage("UserName cannot be empty.")
            .MaximumLength(100).WithMessage("Username length cannot be more than 100");
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .NotNull().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("A valid email is required")
            .MaximumLength(100).WithMessage("Email length cannot be more than 100");
        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .NotNull().WithMessage("Password cannot be empty.")
            .MaximumLength(100).WithMessage("Password length cannot be more than 100");;
    }
}