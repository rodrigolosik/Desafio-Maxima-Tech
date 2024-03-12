using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IDbConnection>(x => new MySqlConnection(configuration.GetConnectionString("Default")))
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}
