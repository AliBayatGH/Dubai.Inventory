using Dubai.Inventory.Api.Products.Endpoints;

namespace Dubai.Inventory.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static WebApplication Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler();
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapProductEndpoints();

        return app;
    }
}