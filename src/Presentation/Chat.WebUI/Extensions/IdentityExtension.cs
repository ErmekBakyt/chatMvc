using Chat.Core.Identity;
using Chat.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;

namespace Chat.WebUI.Extensions;

public static class IdentityExtension
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection service)
    {
        service.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            
        }).AddEntityFrameworkStores<AppDbContext>();

        CookieBuilder cookieBuilder = new CookieBuilder();
        cookieBuilder.Name = "Chat";
        cookieBuilder.HttpOnly = true;
        cookieBuilder.SameSite = SameSiteMode.Lax;
        cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        service.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = new PathString("/Account/Login");
            options.SlidingExpiration = true; // eger user site ka kirse expiration time kaira auto uzara beret
            options.Cookie = cookieBuilder;
            options.ExpireTimeSpan = TimeSpan.FromHours(1);
        });

        return service;
    }
}