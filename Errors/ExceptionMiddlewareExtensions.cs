namespace Library_management_system_API.Errors;

using System.Net;
using Library_management_system_API.Dto;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

public static class ExceptionsMiddlewareExtensions
{
    public static void ConfigureBuildInExceptionHandlers(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDto()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Path = contextRequest.Path,
                        }.ToString());
                    }
                });
            }
        );
    }
}
