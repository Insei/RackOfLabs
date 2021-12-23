using RackOfLabs.Application.Interfaces.Generic;
using Microsoft.Extensions.DependencyInjection;
using RackOfLabs.Infrastructure.Persistence.Repositories;

namespace RackOfLabs.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepositoryAsync, GenericRepository>();
        return services;
    }
}