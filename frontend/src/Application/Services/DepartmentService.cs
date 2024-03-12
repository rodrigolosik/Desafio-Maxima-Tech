using Domain.ViewModels;
using Infrastructure.Gateways;
using Mapster;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentApiGateway _departmentApiGateway;

    public DepartmentService(IDepartmentApiGateway departmentApiGateway)
    {
        _departmentApiGateway = departmentApiGateway;
    }

    public async Task<IEnumerable<DepartmentViewModel>> GetAllAsync()
    {
        var departments = await _departmentApiGateway.GetAllAsync();

        var result = departments.Adapt<IEnumerable<DepartmentViewModel>>();

        return result;
    }
}
