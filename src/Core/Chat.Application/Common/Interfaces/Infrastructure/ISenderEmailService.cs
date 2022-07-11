using Chat.Application.Common.Models;

namespace Chat.Application.Common.Interfaces.Infrastructure;

public interface ISenderEmailService
{
    Task SendEmailAsync(EmailMessage message);
}