using Dubai.Inventory.Api.Extensions;
using Dubai.Inventory.Application.Exceptions;

namespace Dubai.Inventory.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _request;

    public ExceptionHandlerMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (HttpResponseException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            var error = exception.ToProblemDetails(exception.StatusCode);
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}