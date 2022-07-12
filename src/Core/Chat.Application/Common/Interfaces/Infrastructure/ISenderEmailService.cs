using Chat.Application.Common.Models;

namespace Chat.Application.Common.Interfaces.Infrastructure;

public interface ISenderEmailService
{
    Task<Result> SendEmailAsync(EmailMessage message);
}