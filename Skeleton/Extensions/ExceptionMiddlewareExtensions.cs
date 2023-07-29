using Microsoft.AspNetCore.Diagnostics;
using Skeleton.Abstraction;
using Skeleton.Entities.ErrorModels;
using System.Net;
using Skeleton.Entities.Exceptions;

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
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    
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