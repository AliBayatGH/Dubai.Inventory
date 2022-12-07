using Dubai.Inventory.Application.Products.Queries;
using Dubai.Inventory.Domain.Products;
using Dubai.Inventory.Infrastructure;
using Dubai.Inventory.Infrastructure.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dubai.Inventory.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<ApplicationDbContext>(optrions => optrions.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddMediatR(typeof(GetProductCountQuery));
        services.AddTransient<IProductRepository, ProductRepository>();

        return services;
    }
}