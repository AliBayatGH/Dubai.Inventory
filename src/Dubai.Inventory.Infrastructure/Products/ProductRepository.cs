using Dubai.Inventory.Domain.Products;
using Dubai.Inventory.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dubai.Inventory.Infrastructure.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<bool> ChnageProductStatusAsync(int id, ProductStatus productStatus, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(id, cancellationToken);

        if (product is null)
            return false;

        product.ChangeStatus(productStatus);

        return true;
    }
    public async Task<bool> SellProductAsync(int id, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(id, cancellationToken);

        if (product is null)
            return false;

        product.Sell();

        return true;
    }
    public async Task<int> GetProductsByStatusCountAsync(ProductStatus productStatus)
    {
        return await _context.Products.CountAsync(x => x.ProductStatus == productStatus);
    }
}
