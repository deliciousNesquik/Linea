using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Linea.Core.Interface;
using Linea.Core.Models;

namespace Linea.Core.Services;

public class ControlMetadataService: IControlMetadataService
{ 
    public List<Control> LoadControls(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Файл не найден: {path}");

        var json = File.ReadAllText(path);

        var result = JsonSerializer.Deserialize<List<Control>>(json);

        if (result == null)
            throw new InvalidOperationException("Не удалось десериализовать файл controls.json.");
        
        return [..result];
    }
}