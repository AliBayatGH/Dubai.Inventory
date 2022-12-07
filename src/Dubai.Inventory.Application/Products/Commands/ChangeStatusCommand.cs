using Dubai.Inventory.Application.Exceptions;
using Dubai.Inventory.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dubai.Inventory.Application.Products.Commands;

public record ChangeStatusCommand(int Id, ProductStatus ProductStatus) : IRequest;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand>
{
    private readonly IProductRepository _productRepository;

    public ChangeStatusCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.ChnageProductStatusAsync(request.Id, request.ProductStatus, cancellationToken);

        if (result is false)
        {
            throw new HttpResponseException(StatusCodes.Status404NotFound, "Product is not found!");
        }

        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return default;
    }
}