using Dubai.Inventory.Application.Exceptions;
using Dubai.Inventory.Application.Products.Commands;
using Dubai.Inventory.Domain.Products;
using Moq;
using Xunit;

namespace Dubai.Inventory.FunctionalTest.Products
{
    public class ChangeStatusCommandTests
    {
        private readonly Mock<IProductRepository> _productRepository = new();
        [Fact]
        public async Task ChangeProductStatusAsync_When_Id_Is_Not_Valid_Throw_Exception()
        {
            // Arrange
            var productStatus = ProductStatus.InStock;
            var id = 2;

            _productRepository.Setup(x => x.ChnageProductStatusAsync(It.IsAny<int>(), It.IsAny<ProductStatus>(), default)).ReturnsAsync(false);

            // Act
            var handler = new ChangeStatusCommandHandler(_productRepository.Object);

            //Assert
            await Assert.ThrowsAsync<HttpResponseException>(async () => await handler.Handle(new ChangeStatusCommand(id, productStatus), default));
        }

        [Fact]
        public async Task ChangeProductStatusAsync_When_Id_Is_Valid_Return_Default()
        {
            // Arrange
            var productStatus = ProductStatus.InStock;
            var id = 2;

            _productRepository.Setup(x => x.ChnageProductStatusAsync(It.IsAny<int>(), It.IsAny<ProductStatus>(), default)).ReturnsAsync(true);

            _productRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
          
            // Act
            var handler = new ChangeStatusCommandHandler(_productRepository.Object);
            var result = await handler.Handle(new ChangeStatusCommand(id, productStatus), default);

            //Assert
            Assert.Equal(default,result);
            Assert.NotNull(result);
        }
    }
}
