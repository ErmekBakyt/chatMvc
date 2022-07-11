using FluentValidation;

namespace Chat.Application.Features.Account.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(v => v.Email)
            .NotNull().WithMessage("Email cannot be empty")
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Email format not supported");
    }
}