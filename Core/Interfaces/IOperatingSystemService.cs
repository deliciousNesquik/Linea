namespace Linea.Core.Interfaces;

public interface IOperatingSystemService
{
    public static bool IsWindows { get; set; }
    public static bool IsMacOS { get; set; }
    public static bool IsLinux { get; set; }
    string GetPlatformName(); // Например: "Windows", "macOS", "Linux"
}