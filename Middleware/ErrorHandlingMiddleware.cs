using Newtonsoft.Json;
using Npgsql;
using System.Net;
using WassamaraManagement.Middleware.Exceptions;

namespace WassamaraManagement.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;

            if (exception is BadRequestException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (exception is NpgsqlException)
            {
                code = HttpStatusCode.InternalServerError;
            }
            else if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound; 
            }
            else
            {
                code = HttpStatusCode.InternalServerError; 
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
