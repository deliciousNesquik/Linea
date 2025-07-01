namespace Linea.Core.Interfaces;

public interface IOperatingSystemService
{
    bool IsWindows();
    bool IsMacOS();
    bool IsLinux();
    string GetPlatformName(); // Например: "Windows", "macOS", "Linux"
}