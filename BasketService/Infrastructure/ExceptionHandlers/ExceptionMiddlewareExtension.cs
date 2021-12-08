using Microsoft.AspNetCore.Builder;

namespace BasketService.Infrastructure.ExceptionHandlers
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
