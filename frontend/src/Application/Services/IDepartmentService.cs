using Domain.Dtos.Departments;
using Domain.ViewModels;

namespace Application.Services;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentViewModel>> GetAllAsync();
}
