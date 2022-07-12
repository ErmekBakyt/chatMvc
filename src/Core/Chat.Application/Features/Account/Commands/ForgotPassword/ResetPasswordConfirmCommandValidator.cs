using FluentValidation;

namespace Chat.Application.Features.Account.Commands.ForgotPassword;

public class ResetPasswordConfirmCommandValidator : AbstractValidator<ResetPasswordConfirmCommand>
{
    public ResetPasswordConfirmCommandValidator()
    {
        RuleFor(v => v.NewPassword)
            .NotEmpty().WithMessage("New password cannot be empty")
            .NotNull().WithMessage("New password cannot be empty");

    }
}