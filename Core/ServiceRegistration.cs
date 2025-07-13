using Linea.Core.Interfaces;
using Linea.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Linea.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddLineaCore(this IServiceCollection services)
    {
        services.AddSingleton<IControlMetadata, ControlMetadata>();
        services.AddSingleton<ILocalization, LocalizationService>();
        services.AddSingleton<IMarkupRules, MarkupRules>();
        services.AddSingleton<IMarkupBuilder, MarkupBuilder>();
        services.AddSingleton<IMarkupFormatter, MarkupFormatter>();
        services.AddSingleton<IMarkupGenerator, MarkupGenerator>();
        
        return services;
    }
}