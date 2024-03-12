using Domain.Dtos.Products;
using Domain.ViewModels;
using Infrastructure.Gateways;
using Mapster;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductApiGateway _productApiGateway;

    public ProductService(IProductApiGateway productApiGateway)
    {
        _productApiGateway = productApiGateway;
    }

    public async Task CreateAsync(ProductViewModel productViewModel)
    {
        var productDto = productViewModel.Adapt<RequestProductDto>();

        await _productApiGateway.CreateAsync(productDto);
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var products = await _productApiGateway.GetAllAsync();

        var result = products.Adapt<IEnumerable<ProductViewModel>>();
        return result;
    }

    public async Task<ProductViewModel> GetByIdAsync(Guid id)
    {
        var product = await _productApiGateway.GetByIdAsync(id);

        var result = product.Adapt<ProductViewModel>();

        return result;
    }

    public Task UpdateAsync(ProductViewModel productViewModel)
    {
        throw new NotImplementedException();
    }
}
