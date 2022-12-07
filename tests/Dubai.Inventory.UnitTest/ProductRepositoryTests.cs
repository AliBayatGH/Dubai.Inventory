using Dubai.Inventory.Domain.Products;
using Dubai.Inventory.Infrastructure.Products;
using Dubai.Inventory.UnitTest.Config;
using Xunit;

namespace Dubai.Inventory.UnitTest;

public class ProductRepositoryTests : MemoryDatabaseTestConfig
{
    private readonly ProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _productRepository = new ProductRepository(Context);
    }

    #region GetProductsByStatusCountAsync

    [Fact]
    public async Task GetProductsByStatusCountAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        ProductStatus productStatus = ProductStatus.InStock;

        // Act
        var result = await _productRepository.GetProductsByStatusCountAsync(productStatus);

        // Assert
        Assert.Equal(3, result);
    }

    #endregion

    #region ChnageProductStatusAsync

    [Fact]
    public async Task ChangeProductStatusAsync_When_Id_Is_Valid_Return_True()
    {
        // Arrange
        int id = 3;
        ProductStatus productStatus = ProductStatus.Sold;

        // Act
        var result = await _productRepository.ChnageProductStatusAsync(id, productStatus, default);
        await _productRepository.UnitOfWork.SaveChangesAsync();

        var getSoldProductStatus = Context.Products.First(p => p.Id==id);

        // Assert
        Assert.True(result);
        Assert.Equal(productStatus, getSoldProductStatus.ProductStatus);
    }

    [Fact]
    public async Task ChangeProductStatusAsync_When_Id_Is_Not_Valid_Return_False()
    {
        // Arrange
        int id = 0;
        ProductStatus productStatus = ProductStatus.Sold;

        // Act
        var result = await _productRepository.ChnageProductStatusAsync(id, productStatus, default);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region SellProductAsync

    [Theory]
    [InlineData(3, true)]
    [InlineData(0, false)]
    public async Task SellProductAsync_When_Id_Is_Valid_Return_True(int id, bool expected)
    {
        // Act
        var result = await _productRepository.SellProductAsync(id,default);
        await _productRepository.UnitOfWork.SaveChangesAsync();

        var getSoldProductStatus = Context.Products.Where(p => p.ProductStatus == ProductStatus.Sold).ToList();

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion
}