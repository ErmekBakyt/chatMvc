using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddFluentValidation(fv =>  fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}