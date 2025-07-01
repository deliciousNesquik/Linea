using Linea.UI.ViewModels;
using Linea.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Linea.UI;

public static class ServiceRegistration
{
    public static IServiceCollection AddLineaUI(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }
}