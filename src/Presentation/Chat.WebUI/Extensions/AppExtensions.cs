using System.Net;
using Chat.Application.Common.Exceptions;
using Chat.WebUI.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Chat.WebUI.Extensions;

public static class AppExtensions
{
    public static void ConfigureExceptionHandling(this IApplicationBuilder app, bool includeExceptionDetail)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null) await HandleException(context, contextFeature, includeExceptionDetail);
            });
        });
    }

    private static async Task HandleException(HttpContext context, IExceptionHandlerFeature contextFeature,
        bool includeExceptionDetail)
    {
        var statusCode = contextFeature.Error switch
        {
            ClientSideException => HttpStatusCode.BadRequest,
            NotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        var errorModel =
            new ErrorViewModel(includeExceptionDetail ? contextFeature.Error.ToString() : contextFeature.Error.Message);
        await WriteResponseAsync(context, statusCode, errorModel);
    }

    private static async Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode,
        ErrorViewModel errorModel)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(errorModel);
    }
}