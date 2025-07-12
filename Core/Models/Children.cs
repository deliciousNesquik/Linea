using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Linea.Core.Models;

public class Children
{
    public List<Control> Content { get; set; } = [];
    
    [JsonPropertyName("allow")]
    public bool Allow { get; set; } = false;
    
    [JsonPropertyName("maxCount")]
    public int MaxCount { get; set; } = 0;
    
    [JsonPropertyName("descriptionKey")]
    public string Description { get; set; } = string.Empty;
    
    public Children Clone()
    {
        return new Children
        {
            Content = this.Content.Select(child => child.Clone()).ToList(),
            Allow = this.Allow,
            MaxCount = this.MaxCount,
            Description = this.Description
        };
    }
    
}