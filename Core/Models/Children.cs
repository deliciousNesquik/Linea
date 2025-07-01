using System.Text.Json.Serialization;

namespace Linea.Core.Models;

public class Children
{
    [JsonPropertyName("allow")]
    public bool Allow { get; set; } = false;
    
    [JsonPropertyName("maxCount")]
    public int MaxCount { get; set; } = 0;
    
    [JsonPropertyName("descriptionKey")]
    public string Description { get; set; } = string.Empty;
    
}