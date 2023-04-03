using PokeGame.Domain.Exceptions;
using System.Text.Json;

namespace PokeGame.Api.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (ValidationFailedException exception)
			{
				context.Response.ContentType = "application/json";

				context.Response.StatusCode = StatusCodes.Status400BadRequest;

				await context.Response.WriteAsync(JsonSerializer.Serialize(exception.ValidationFailures));
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
