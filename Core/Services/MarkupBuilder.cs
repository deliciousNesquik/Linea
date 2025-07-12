using System.Collections.Generic;
using System.Linq;
using Linea.Core.Enum;
using Linea.Core.Interfaces;
using Linea.Core.Models;

namespace Linea.Core.Services;

public class MarkupBuilder : IMarkupBuilder
{
    public List<(StructureType Type, string Text, int Level)> Build(Control control)
    {
        var markupList = new List<(
            StructureType Type, 
            string Text, 
            int Level
            )>();
        
        BuildControl(markupList, control);
        return markupList;
    }
    
    private static void BuildControl(List<(StructureType Type, string Text, int Level)> markupList, Control control, int depthLevel = 0)
    {
        markupList.Add((StructureType.OpenTag, control.Name, depthLevel));
        
        var attributesCopy = control.Attributes.Select(a => a.Clone()).ToList();
        if (control.Children.Content.Count > 0)
        {
            var containerIndex = control.Attributes.FindIndex(attr => attr.IsContainer);
            if (containerIndex != -1)
                attributesCopy.RemoveAt(containerIndex);
        }
        BuildAttribute(markupList, attributesCopy);

        if (control.Children?.Content is { Count: > 0 })
            foreach (var child in control.Children.Content)
                BuildControl(markupList, child, depthLevel + 1);
        
        markupList.Add((StructureType.CloseTag, control.Name, depthLevel));
    }
    
    private static void BuildAttribute(List<(StructureType Type, string Text, int Level)> markupList, List<Attribute> attributes)
    {
        var level = markupList[^1].Item3 + 1;
        markupList.AddRange(
            from attribute in attributes 
            where !string.IsNullOrEmpty(attribute.Value) 
            select (StructureType.Attribute, $"{attribute.Name}=\"{attribute.Value}\"", level)
        );
    }
}