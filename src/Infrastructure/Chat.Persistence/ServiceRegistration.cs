using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("ChatConnectionString"),
                b => b.MigrationsAssembly("Chat.Persistence")));
        service.AddScoped<IAppDbContext, AppDbContext>();

      
        return service;
    }
}