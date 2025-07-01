using System;
using Linea.Core.Interfaces;

namespace Linea.Core.Services;

public class OperatingSystemService : IOperatingSystemService
{
    public bool IsWindows() =>
        OperatingSystem.IsWindows();

    public bool IsMacOS() =>
        OperatingSystem.IsMacOS();

    public bool IsLinux() =>
        OperatingSystem.IsLinux();

    public string GetPlatformName()
    {
        if (IsWindows()) return "Windows";
        if (IsMacOS()) return "macOS";
        if (IsLinux()) return "Linux";
        return "Unknown";
    }
}