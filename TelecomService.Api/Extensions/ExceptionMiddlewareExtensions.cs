using Microsoft.AspNetCore.Builder;
using TelecomService.Api.CustomExceptionMiddleware;

namespace TelecomService.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
