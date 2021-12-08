using System.Net;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace BasketService.Infrastructure.ExceptionHandlers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException cause)
            {
                await HandleExceptionAsync(httpContext, cause);
            }
        }
        
        private Task HandleExceptionAsync(HttpContext context, NotFoundException cause)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.NotFound;

            return context.Response.WriteAsync(new ErrorDetails(cause.Message).ToJson());
        }
    }
}
