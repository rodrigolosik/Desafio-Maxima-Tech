using Domain.Dtos.Products;
using Domain.ViewModels;
using Infrastructure.Gateways;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IProductApiGateway _productApiGateway;

    public ProductService(ILogger<ProductService> logger, IProductApiGateway productApiGateway)
    {
        _logger = logger;
        _productApiGateway = productApiGateway;
    }

    public async Task CreateAsync(ProductViewModel productViewModel)
    {
        try
        {
            var productDto = productViewModel.Adapt<RequestProductDto>();

            await _productApiGateway.CreateAsync(productDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Error trying to create new product.");
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        try
        {
            var products = await _productApiGateway.GetAllAsync();

            var result = products.Adapt<IEnumerable<ProductViewModel>>();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Error trying to get list of products.");
        }
    }

    public async Task<ProductViewModel> GetByIdAsync(Guid id)
    {
        try
        {
            var product = await _productApiGateway.GetByIdAsync(id);

            var result = product.Adapt<ProductViewModel>();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Error trying to get Product by Id.");
        }
    }

    public async Task UpdateAsync(ProductViewModel productViewModel)
    {
        try
        {
            var productDto = productViewModel.Adapt<RequestProductDto>();

            await _productApiGateway.UpdateAsync(productViewModel.Id, productDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Error trying to update Product.");
        }
    }
}
