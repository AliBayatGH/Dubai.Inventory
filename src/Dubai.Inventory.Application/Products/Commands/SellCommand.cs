using Dubai.Inventory.Application.Exceptions;
using Dubai.Inventory.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dubai.Inventory.Application.Products.Commands;

public record SellCommand(int Id) : IRequest;

public class SellCommandHandler : IRequestHandler<SellCommand>
{
    private readonly IProductRepository _productRepository;

    public SellCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(SellCommand request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.SellProductAsync(request.Id, cancellationToken);

        if (result is false)
        {
            throw new HttpResponseException(StatusCodes.Status404NotFound, "Product is not found!");
        }

        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return default;
    }
}