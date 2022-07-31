using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Chat.Application;
using Chat.Persistence;
using Chat.Service;
using Chat.WebUI.Extensions;
using Chat.WebUI.Infrastructure.Hubs;
using Chat.WebUI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPersistenceRegistration(builder.Configuration)
    .AddApplicationRegistration()
    .AddIdentityConfiguration()
    .AddServiceSettingsConfiguration(builder.Configuration);
builder.Services.AddNotyf(options =>
{
    options.Position = NotyfPosition.TopCenter;
    options.IsDismissable = true;
    options.DurationInSeconds = 30;
    options.HasRippleEffect = false;
});
builder.Services.AddScoped<ChatService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Chat/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.ConfigureExceptionHandling(!app.Environment.IsDevelopment());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();

app.MapControllerRoute(
    "default",
    "{controller=Chat}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chat");

app.Run();