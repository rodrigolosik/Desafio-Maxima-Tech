using Domain.Models;

namespace Application.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> ListAllAsync();
}
