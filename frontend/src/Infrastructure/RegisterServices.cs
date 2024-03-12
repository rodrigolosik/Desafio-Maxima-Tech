using Infrastructure.Gateways;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var urlBase = "http://localhost:5253/api";

        services.AddRefitClient<IProductApiGateway>().ConfigureHttpClient(c => c.BaseAddress = new Uri(urlBase));
        services.AddRefitClient<IDepartmentApiGateway>().ConfigureHttpClient(c => c.BaseAddress = new Uri(urlBase));

        return services;
    }
}
