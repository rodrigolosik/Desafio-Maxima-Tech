using Domain.Dtos;
using Domain.Models;
using Infrastructure.Repositories;
using Mapster;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task CreateAsync(ProductDto productDto)
    {
        var product = productDto.Adapt<Product>();

        await _productRepository.CreateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        var productsDto = products.Adapt<IEnumerable<ProductDto>>();

        return productsDto;
    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        var productDto = product.Adapt<ProductDto>();

        return productDto;
    }

    public async Task UpdateAsync(Guid id, ProductDto productDto)
    {
        var product = productDto.Adapt<Product>();

        await _productRepository.UpdateAsync(id, product);
    }
}
