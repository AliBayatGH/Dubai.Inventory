using Dubai.Inventory.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

WebApplication app = builder.Build();

app.Configure();

app.Run();