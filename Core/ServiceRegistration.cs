using Linea.Core.Interface;
using Linea.Core.Interfaces;
using Linea.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Linea.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddLineaCore(this IServiceCollection services)
    {
        services.AddSingleton<IOperatingSystemService, OperatingSystemService>();
        services.AddSingleton<IControlMetadataService, ControlMetadataService>();
        services.AddSingleton<ILocalizationService, LocalizationService>();

        return services;
    }
}