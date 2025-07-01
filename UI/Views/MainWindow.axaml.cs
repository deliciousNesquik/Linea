using System.IO;
using Avalonia.Controls;
using Linea.Core.Interfaces;

namespace Linea.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow(IOperatingSystemService operatingSystemService)
    {
        InitializeComponent();
        
        // Установка логотипа (ico / icns) в зависимости от запускаемой платформы.
        var iconPath = operatingSystemService.IsMacOS() 
            ? "Assets/icons/icon.icns"
            : "Assets/icons/icon.ico";

        if (File.Exists(iconPath))
            this.Icon = new WindowIcon(iconPath);
        
    }
}