using System.Collections.Generic;
using System.Linq;
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

    public Control Clone()
    {
        return new Control
        {
            Name = this.Name,
            Children = this.Children.Clone(),
            Attributes = this.Attributes.Select(attr => attr.Clone()).ToList()
        };
    }
}