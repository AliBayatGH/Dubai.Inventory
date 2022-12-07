using System.Net;
using System.Net.Http.Json;
using Dubai.Inventory.Domain.Products;

namespace Dubai.Inventory.Api.IntegrationTest.Products;

public class ProductEndpointsTests : IClassFixture<InventoryApiFactory>
{
    private readonly HttpClient _client;


    public ProductEndpointsTests(InventoryApiFactory apiFactory)
    {
        _client = apiFactory.CreateClient();
    }

    #region GetAllProductCountAsync

    [Fact]
    public async Task GetAllProductCountAsync_Works_Properly_Return_Ok()
    {
        // Arrange
        var productStatus = ProductStatus.InStock;

        // Act
        var response = await _client.GetAsync($"api/Product?productStatus={productStatus}");
        var retrievedProduct = await response.Content.ReadFromJsonAsync<int>();

        // Assert
        Assert.Equal(3, retrievedProduct);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    #endregion

    #region ChangeProductStatusAsync

    [Fact]
    public async Task ChangeProductStatusAsync_When_Id_Is_Not_Valid_Return_Bad_Request()
    {
        // Arrange
        var id = 0;
        var productStatus = ProductStatus.InStock;

        // Act
        var response = await _client.GetAsync($"/change-status/{id}/?productStatus={productStatus}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ChangeProductStatusAsync_Works_Properly_Return_NoContent()
    {
        // Arrange
        var id = 1;
        var productStatus = ProductStatus.InStock;

        // Act
        var response = await _client.GetAsync($"/change-status/{id}/?productStatus={productStatus}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    #endregion

    #region SellProductAsync

    [Fact]
    public async Task SellProductAsync_When_Id_Is_Not_Valid_Return_NotFound()
    {
        // Arrange
        var id = 0;

        // Act
        var response = await _client.PostAsync($"/sell/{id}",null);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

    }

    [Fact]
    public async Task SellProductAsync_When_Id_Is_Valid_Return_NoContent()
    {
        // Arrange
        var id = 1;

        // Act
        var response = await _client.PostAsync($"/sell/{id}", null);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

    }

    #endregion
}
