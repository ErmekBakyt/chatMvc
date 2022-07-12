using Chat.Application.Common.Interfaces.Infrastructure;
using Chat.Application.Common.Models;
using Chat.Application.Common.Settings;
using MailKit.Net.Smtp;
using MimeKit;

namespace Chat.Service.Infrastructure;

public class EmailSenderService : ISenderEmailService
{
    private readonly EmailConfigurationSettings _emailConfiguration;

    public EmailSenderService(EmailConfigurationSettings emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }

    public async Task<Result> SendEmailAsync(EmailMessage message)
    {
        var emailMessage = CreateEmailMessage(message);
        var result = await Send(emailMessage);
        return result.Succeed ? Result.Success() : Result.Failure(result.Message);
    }
    
    private MimeMessage CreateEmailMessage(EmailMessage message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("email",_emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        return emailMessage;
    }

    private async Task<Result> Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, useSsl: true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

            await client.SendAsync(mailMessage);
        }
        catch (Exception e)
        {
            return Result.Failure(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }

        return Result.Success();
    }
}