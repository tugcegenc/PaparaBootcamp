using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ProductManagement.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Continue request pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            // First, create the default error message.
            object response = new { message = "An error occurred.", error = ex.Message };

            // Check specific exception types
            if (ex is ValidationException validationException)
            {
                statusCode = HttpStatusCode.BadRequest;
    
                // Converting error messages into a single string.
                var errorMessages = string.Join("; ", validationException.Errors.Select(e => e.ErrorMessage));

                response = new
                {
                    message = "Validation failed!",
                    error = errorMessages // Error will now be a single string.
                };
            }
            else if (ex is KeyNotFoundException) // Data not found
            {
                statusCode = HttpStatusCode.NotFound;
                response = new { message = "Requested data was not found.", error = ex.Message };
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}