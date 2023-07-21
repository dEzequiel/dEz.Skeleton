using Microsoft.AspNetCore.Diagnostics;
using Skeleton.Abstraction;
using Skeleton.Entities.ErrorModels;
using System.Net;

namespace Skeleton.Extensions;

public static class ExceptionMiddlewareExtensions
{
    private const string APP_JSON_CONTENT_TYPE = "application/json";

    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        /// Catch exception (middleware) and managed in a custom way.
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = APP_JSON_CONTENT_TYPE;

                /// IExceptionHandlerFeature gives a vision of the error.
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError($"Something went wrong: {contextFeature.Error}");
                    await context.Response.WriteAsync(new ApiErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Path = context.Request.Path,
                        Method = context.Request.Method
                    }.ToString());
                }
            });
        });
    }
}