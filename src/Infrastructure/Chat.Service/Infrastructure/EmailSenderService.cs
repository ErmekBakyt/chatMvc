using Chat.Application.Common.Interfaces.Infrastructure;
using Chat.Application.Common.Models;
using Chat.Core.Entities;
using MailKit.Net.Smtp;
using MimeKit;

namespace Chat.Service.Infrastructure;

public class EmailSenderService : ISenderEmailService
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailSenderService(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        var emailMessage = CreateEmailMessage(message);
        await Send(emailMessage);
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

    private async Task Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

            await client.SendAsync(mailMessage);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}