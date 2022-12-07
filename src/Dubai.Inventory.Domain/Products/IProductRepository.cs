using Dubai.Inventory.SharedKernel.Interfaces;

namespace Dubai.Inventory.Domain.Products;
public interface IProductRepository
{
    Task<bool> ChnageProductStatusAsync(int id, ProductStatus productStatus, CancellationToken cancellationToken=default);
    Task<bool> SellProductAsync(int id, CancellationToken cancellationToken=default);
    Task<int> GetProductsByStatusCountAsync(ProductStatus productStatus);

    IUnitOfWork UnitOfWork { get; }
}
