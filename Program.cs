using Avalonia;
using System;
using System.Collections.Generic;
using Avalonia.Svg.Skia;
using Linea.Core;
using Linea.Core.Interfaces;
using Linea.Core.Models;
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
            .AddLineaUI()
            .AddLineaCore()
            .BuildServiceProvider();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
        
    }

    private static AppBuilder BuildAvaloniaApp()
    {
        GC.KeepAlive(typeof(SvgImageExtension).Assembly);
        GC.KeepAlive(typeof(Svg.Skia.SKSvg).Assembly);
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}