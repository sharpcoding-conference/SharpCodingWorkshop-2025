using Microsoft.AspNetCore.Http;
using CommunityHub.Application.Exceptions;
using CommunityHub.Domain.Exceptions;
using System.Text.Json;

namespace CommunityHub.Application.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = ex switch
                {
                    BookingNotFoundException        => StatusCodes.Status404NotFound,
                    UserNotFoundException           => StatusCodes.Status404NotFound,
                    WebinarNotFoundException        => StatusCodes.Status404NotFound,
                    BookingLimitExceededException   => StatusCodes.Status400BadRequest,
                    WebinarNotAvailableException    => StatusCodes.Status400BadRequest,
                    _                               => StatusCodes.Status500InternalServerError
                };

                await response.WriteAsync(JsonSerializer.Serialize(ex.Message));
            }
        }
    }
}
