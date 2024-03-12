using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class RegisterServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IDepartmentService, DepartmentService>();
    }
}
