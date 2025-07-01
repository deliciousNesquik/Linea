using System.Collections.Generic;
using System.Text.Json.Serialization;
using Linea.Core.Models;

namespace Linea.Core.Models;

public class Control
{
    [JsonPropertyName("control")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("children")]
    public required Children Children { get; set; }
    
    [JsonPropertyName("attributes")]
    public required List<Attribute> Attributes { get; set; }
}