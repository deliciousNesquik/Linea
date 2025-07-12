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
    
    [JsonPropertyName("isContainer")]
    public bool IsContainer { get; set; } = false;
    
    public Attribute Clone()
    {
        return new Attribute
        {
            Name = this.Name,
            Value = this.Value,
            Type = this.Type,
            Category = this.Category,
            DefaultValue = this.DefaultValue,
            Description = this.Description,
            Advanced = this.Advanced,
            IsContainer = this.IsContainer
        };
    }

}