using Domain.ViewModels;

namespace Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetByIdAsync(Guid id);
    Task CreateAsync(ProductViewModel productViewModel);
    Task UpdateAsync(ProductViewModel productViewModel);
}
