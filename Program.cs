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
        
        Control button1 = controls[0].Clone();
        Control button2 = controls[0].Clone();
        Control button3 = controls[0].Clone();

        button1.Attributes[0].Value = "Button 1";
        button1.Attributes[1].Value = "200";
        button1.Attributes[2].Value = "30";
        
        button2.Attributes[0].Value = "Button 2";
        button3.Attributes[0].Value = "Button 3";

        button2.Children.Content.Add(button3);
        button1.Children.Content.Add(button2);
        

        Console.WriteLine(Core.Services.MarkupGenerationService.Generate(button1));
        
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