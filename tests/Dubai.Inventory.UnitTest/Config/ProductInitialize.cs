using Dubai.Inventory.Domain.Products;
using Dubai.Inventory.Infrastructure;

namespace Dubai.Inventory.UnitTest.Config;
internal class ProductInitialize
{
    public void Initialize(ApplicationDbContext context)
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name="Product1",
                    Barcode="123456",
                    CategoryName="Category",
                    Description="Description",
                    IsWeighted=false,
                },
                 new()
                 {
                    Id = 2,
                    Name="Product2",
                    Barcode="123456",
                    CategoryName="Category2",
                    Description="Description2",
                    IsWeighted=false,
                },
                new()
                {
                    Id = 3,
                    Name="Product3",
                    Barcode="123456",
                    CategoryName="Category2",
                    Description="Description2",
                    IsWeighted=false,
                },
                new()
                {
                    Id = 4,
                    Name="Product4",
                    Barcode="123456",
                    CategoryName="Category2",
                    Description="Description4",
                    IsWeighted=false,
                }
            };
            context.Products.AddRange(products);

            context.SaveChanges();
        }
    }
}
