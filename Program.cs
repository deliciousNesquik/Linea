using Avalonia;
using System;
using System.IO;
using System.Linq;
using Linea.Core;
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
        var controls = Core.Services.ControlMetadataService.LoadControls("Core/Metadata/controls.json");

        Control button1 = controls[0];
        Control button2 = controls[0];

        button1.Attributes[0].Value = "10";
        button2.Attributes[0].Value = "20";
        
        foreach (var attribute in button1.Attributes)
        {
            Console.WriteLine(attribute.Name + ": " + attribute.Value);
        }
        
        Services = new ServiceCollection()
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