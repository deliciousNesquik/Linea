using System.IO;
using Avalonia.Controls;
using Linea.Core.Interfaces;

namespace Linea.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Установка логотипа (ico / icns) в зависимости от запускаемой платформы.
        var iconPath = Core.Services.OperatingSystemService.IsMacOS
            ? "Assets/icons/icon.icns"
            : "Assets/icons/icon.ico";

        if (File.Exists(iconPath))
            this.Icon = new WindowIcon(iconPath);
        
    }
}