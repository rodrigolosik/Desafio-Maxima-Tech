using Domain.Dtos.Departments;
using Refit;

namespace Infrastructure.Gateways;

public interface IDepartmentApiGateway
{
    [Get("/Departments")]
    Task<IEnumerable<ResponseDepartmentsDto>> GetAllAsync();

}