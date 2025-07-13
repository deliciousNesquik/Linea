using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Linea.Core.Interfaces;
using Linea.Core.Models;

namespace Linea.Core.Services;

public class ControlMetadata: IControlMetadata
{ 
    public List<Control> LoadControls(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"file not found: {path}");

        var json = File.ReadAllText(path);
        var result = JsonSerializer.Deserialize<List<Control>>(json);
        
        if (result == null)
            throw new InvalidOperationException($"Failed to deserialize file: {path}");
        
        return [..result];
    }
}