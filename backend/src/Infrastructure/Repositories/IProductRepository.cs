using Domain.Models;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, Product product);
}
