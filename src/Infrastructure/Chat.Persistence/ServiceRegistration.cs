using Chat.Core.Identity;
using Chat.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ChatConnectionString")));
        service.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

    }
}