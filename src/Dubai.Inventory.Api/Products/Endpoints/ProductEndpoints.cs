using Dubai.Inventory.Application.Products.Commands;
using Dubai.Inventory.Application.Products.Queries;
using Dubai.Inventory.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dubai.Inventory.Api.Products.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/Product", GetAllProductCountAsync);
        app.MapGet("change-status/{id:int}", ChangeProductStatusAsync);
        app.MapPost("sell/{id:int}", SellProductAsync);
    }

    public static async Task<IResult> GetAllProductCountAsync(ISender sender, ProductStatus productStatus)
    {
        var result = await sender.Send(new GetProductCountQuery(productStatus));

        return Results.Ok(result);
    }

    public static async Task<Results<NotFound, NoContent>> ChangeProductStatusAsync(ISender sender, int id, ProductStatus productStatus) 
    {
        await sender.Send(new ChangeStatusCommand(id, productStatus));

        return TypedResults.NoContent();
    }

    public static async Task<Results<NotFound, NoContent>> SellProductAsync(ISender sender, int id)
    {
        await sender.Send(new SellCommand(id));

        return TypedResults.NoContent();
    }
}