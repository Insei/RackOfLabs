using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RackOfLabs.Application.Interfaces.Generic;
using Microsoft.Extensions.DependencyInjection;
using RackOfLabs.Infrastructure.Persistence.Contexts;
using RackOfLabs.Infrastructure.Persistence.Repositories;

namespace RackOfLabs.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services)
    {
        var connectionString = "DataSource=myshareddb;mode=memory;cache=shared";
        var keepAliveConnection = new SqliteConnection(connectionString);
        keepAliveConnection.Open();

        services.AddDbContext<DataDbContext>(options =>
        {
            options.UseSqlite(keepAliveConnection);
        });
        services.AddScoped<IGenericRepositoryAsync, GenericRepository>();
        return services;
    }
}