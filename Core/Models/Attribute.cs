using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Linea.Core.Models;

public class Attribute
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    public string Value { get; set; } = string.Empty;
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;
    
    [JsonPropertyName("defaultValue")]
    public object? DefaultValue { get; set; }
    
    [JsonPropertyName("descriptionKey")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("advanced")]
    public bool Advanced { get; set; } = false;

}