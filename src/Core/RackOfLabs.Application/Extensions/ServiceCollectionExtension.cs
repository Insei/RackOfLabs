using System.Reflection;
using FluentValidation;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.Application.Interfaces.Services;
using RackOfLabs.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RackOfLabs.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IGenericEntityService, GenericEntityService>();
        services.AddScoped<IDeviceService, DeviceService>();
        return services;
    }
}