using Application.Services;
using AutoFixture;
using Domain.Dtos;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Repositories;
using NSubstitute;

namespace UnityTests.Application.Services;

public class ProductServiceTests
{

    private readonly IProductRepository _productRepositoryMock;

    public ProductServiceTests()
    {
        _productRepositoryMock = Substitute.For<IProductRepository>();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn_ListOfProducts()
    {
        // Arrange
        var autoFixture = new Fixture();

        var products = autoFixture.Build<Product>().CreateMany(5);

        var productService = new ProductService(_productRepositoryMock);

        _productRepositoryMock.GetAllAsync().Returns(products);

        // Act
        var result = await productService.GetAllAsync();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(5);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturn_Product()
    {
        // Arrange
        var id = Guid.NewGuid();
        var autoFixture = new Fixture();

        var product = autoFixture.Build<Product>().Create();

        var productService = new ProductService(_productRepositoryMock);

        _productRepositoryMock.GetByIdAsync(id).Returns(product);

        // Act
        var result = await productService.GetByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateProduct_With_Success()
    {
        // Arrange
        var autoFixture = new Fixture();

        var product = autoFixture.Build<Product>().Create();

        var productDto = autoFixture.Build<ProductDto>().Create();

        var productService = new ProductService(_productRepositoryMock);

        await _productRepositoryMock.CreateAsync(product);

        // Act
        await productService.CreateAsync(productDto);

        // Assert
        _productRepositoryMock.Received(1);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteProduct_With_Success()
    {
        // Arrange
        var id = Guid.NewGuid();

        var productService = new ProductService(_productRepositoryMock);

        await _productRepositoryMock.DeleteAsync(id);

        // Act
        await productService.DeleteAsync(id);


        // Assert
        _productRepositoryMock.Received(1);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateProduct_With_Success()
    {
        // Arrange
        var id = Guid.NewGuid();

        var autoFixture = new Fixture();

        var product = autoFixture.Build<Product>().Create();

        var productDto = autoFixture.Build<ProductDto>().Create();

        var productService = new ProductService(_productRepositoryMock);

        await _productRepositoryMock.UpdateAsync(id, product);

        // Act
        await productService.UpdateAsync(id, productDto);


        // Assert
        _productRepositoryMock.Received(1);
    }
}
