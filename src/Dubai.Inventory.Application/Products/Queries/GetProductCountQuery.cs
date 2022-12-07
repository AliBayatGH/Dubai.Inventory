using Dubai.Inventory.Domain.Products;
using MediatR;

namespace Dubai.Inventory.Application.Products.Queries;

public record GetProductCountQuery(ProductStatus ProductStatus) : IRequest<int>;
public class GetProductCountQueryHandler : IRequestHandler<GetProductCountQuery, int>
{
    private readonly IProductRepository _productRepository;

    public GetProductCountQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(GetProductCountQuery request, CancellationToken cancellationToken)
    {
         return await _productRepository.GetProductsByStatusCountAsync(request.ProductStatus);
    }

}