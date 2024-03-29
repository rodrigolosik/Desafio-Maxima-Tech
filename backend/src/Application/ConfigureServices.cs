﻿using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IDepartmentService, DepartmentService>();

        return services;
    }
}
