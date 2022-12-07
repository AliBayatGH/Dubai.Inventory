using Dubai.Inventory.Api.Middlewares;

namespace Dubai.Inventory.Api.Extensions;

internal static class ExceptionMiddlewareExtensions
{
    public static WebApplication UseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }
}