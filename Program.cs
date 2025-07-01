using Avalonia;
using System;
using Linea.Core;
using Linea.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Linea;
abstract class Program
{
    public static IServiceProvider? Services { get; private set; }
    
    [STAThread]
    public static void Main(string[] args)
    {
        Services = new ServiceCollection()
            .AddLineaCore()
            .AddLineaUI()
            .BuildServiceProvider();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}