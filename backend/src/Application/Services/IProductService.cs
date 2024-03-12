using Domain.Models;

namespace Application.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task CreateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, Product product);
}
