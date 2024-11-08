using System.Security.Authentication;
using System.Text.Json;
using MedInfoSystem.Services.Exceptions;

namespace MedInfoSystem.Services.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case BadHttpRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case AuthenticationException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                case
                    NotFoundUser:
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    break;
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new
            {
                status = "Error",
                message = ex.Message
            });

            return context.Response.WriteAsync(result);
        }
    }
}
