using Chat.Application.Common.Interfaces.Infrastructure;
using Chat.Application.Common.Settings;
using Chat.Service.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Service;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var emailConfiguration = configuration.GetSection("EmailConfiguration").Get<EmailConfigurationSettings>();
        services.AddSingleton(emailConfiguration);
        services.AddScoped<ISenderEmailService, EmailSenderService>();
        
        return services;
    }
}