using System;
using Linea.Core.Interfaces;

namespace Linea.Core.Services;

public class OperatingSystemService : IOperatingSystemService
{
    public static bool IsWindows => OperatingSystem.IsWindows();

    public static bool IsMacOS => OperatingSystem.IsMacOS();

    public static bool IsLinux => OperatingSystem.IsLinux();

    public string GetPlatformName()
    {
        if (IsWindows) return "Windows";
        if (IsMacOS) return "macOS";
        return IsLinux ? "Linux" : "Unknown";
    }
}