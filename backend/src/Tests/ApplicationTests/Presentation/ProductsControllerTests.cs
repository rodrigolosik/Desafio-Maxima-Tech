using Application.Services;
using AutoFixture;
using Domain.Dtos;
using GrupoMaxima.Api.Controllers;
using NSubstitute;

namespace UnityTests.Presentation;

public class ProductsControllerTests
{
    private readonly IProductService _productServiceMock;

    public ProductsControllerTests()
    {
        _productServiceMock = Substitute.For<IProductService>();
    }

    [Fact]
    public async Task GetProductsAsync_ShouldReturn_ListOfProducts()
    {
        // Arrange
        var autoFixture = new Fixture();

        var products = autoFixture.Build<ProductDto>().CreateMany(5);

        var productService = new ProductsController(_productServiceMock);

        _productServiceMock.GetAllAsync().Returns(products);

        // Act
        var result = await productService.Get();

        // Assert
        Assert.NotNull(result);
    }
}
