using Linea.Core.Interface;
using Linea.Core.Interfaces;
using Linea.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Linea.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddLineaCore(this IServiceCollection services)
    {
        return services;
    }
}