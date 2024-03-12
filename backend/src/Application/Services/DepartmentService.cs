using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> ListAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }
}
