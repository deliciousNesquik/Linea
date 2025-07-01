using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Linea.UI.ViewModels;
using Linea.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Linea.UI;

public partial class App : Application
{
    public override void Initialize()
    {
        // Установка имени приложения для различных спецификаций систем.
        Current!.Name = "Linea";
        
        // Загрузка содержимого через avalonia xaml loader
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Условие по которому приложение запускается в режиме окна, для Desktop приложений.
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            var mainWindow = Program.Services!.GetRequiredService<MainWindow>();
            var mainWindowViewModel = Program.Services!.GetRequiredService<MainWindowViewModel>();
            
            desktop.MainWindow = mainWindow;
            {
                DataContext = mainWindowViewModel;
            };
        }
        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}