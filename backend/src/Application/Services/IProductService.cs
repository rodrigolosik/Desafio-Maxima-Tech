using Domain.Dtos;
using Domain.Models;

namespace Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid id);
    Task CreateAsync(ProductDto product);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, ProductDto product);
}
