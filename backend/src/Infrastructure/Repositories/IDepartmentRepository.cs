using Domain.Models;

namespace Infrastructure.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync();
}
