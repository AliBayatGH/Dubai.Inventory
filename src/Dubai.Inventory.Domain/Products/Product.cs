using Dubai.Inventory.SharedKernel;
using Dubai.Inventory.SharedKernel.Interfaces;

namespace Dubai.Inventory.Domain.Products;

public class Product : EntityBase, IAggregateRoot
{
    public required string Name { get; init; }
    public required string Barcode { get; init; }
    public string? Description { get; init; }
    public  string? CategoryName { get; init; }
    public required bool IsWeighted { get; init; }
    public ProductStatus ProductStatus { get; private set; } = ProductStatus.InStock;

    public void ChangeStatus(ProductStatus productStatus)
    {
        ProductStatus = productStatus;
    }

    public void Sell()
    {
        ProductStatus = ProductStatus.Sold;
    }
}
public enum ProductStatus
{
    Sold,
    InStock,
    Damaged
}