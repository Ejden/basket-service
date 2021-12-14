using System.Net;
using System.Threading.Tasks;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Client.Shared;
using Microsoft.AspNetCore.Http;
using ValidationException = BasketService.Domain.Shared.ValidationException;

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
            catch (ExternalServiceException cause)
            {
                await HandleExceptionAsync(httpContext, cause);
            }
            catch (ValidationException cause)
            {
                await HandleExceptionAsync(httpContext, cause);
            }
            catch (ServiceException cause)
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
        
        private Task HandleExceptionAsync(HttpContext context, ExternalServiceException cause)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.ServiceUnavailable;

            return context.Response.WriteAsync(new ErrorDetails(cause.Message).ToJson());
        }
        
        private Task HandleExceptionAsync(HttpContext context, ValidationException cause)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(new ErrorDetails(cause.Message).ToJson());
        }
        
        private Task HandleExceptionAsync(HttpContext context, ServiceException cause)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(new ErrorDetails(cause.Message).ToJson());
        }
    }
}
