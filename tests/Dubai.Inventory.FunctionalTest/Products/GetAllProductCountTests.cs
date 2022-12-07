using Dubai.Inventory.Application.Products.Queries;
using Dubai.Inventory.Domain.Products;
using Moq;
using Xunit;

namespace Dubai.Inventory.FunctionalTest.Products;

public class GetAllProductCountTests
{
    private readonly Mock<IProductRepository> _productRepository = new();

    [Fact]
    public async Task GetProductsByStatusCountAsync_When_Id_Is_Valid()
    {
        // Arrange
        var productStatus = ProductStatus.InStock;
        _productRepository.Setup(x => x.GetProductsByStatusCountAsync(It.IsAny<ProductStatus>())).ReturnsAsync(1);

        // Act
        var handler = new GetProductCountQueryHandler(_productRepository.Object);
        var result = await handler.Handle(new GetProductCountQuery(productStatus), default);

        //Assert
          Assert.Equal(1,result);
    }
}
