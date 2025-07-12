using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avalonia.Metadata;
using Linea.Core.Interfaces;
using Linea.Core.Models;

namespace Linea.Core.Services;

public abstract class MarkupGenerationService : IMarkupGenerationService
{

    private static Dictionary<string, bool> GetOrDefaultRules(Dictionary<string, bool>? rules)
    {
        if (rules is null)
            rules = new Dictionary<string, bool>
            {
                { "allowDefaultValues", true },
                { "attributeOnNewLine", false },
                { "useSelfClosingTag", false },
                { "firstAttributeInline", true }
            };
        return rules;
    }
    
    
    public static string Generate(Control control, Dictionary<string, bool>? userRules = null)
    {
        // генерация и форматирование разметки
        // по правилам пользователя или установленным по стандарту.
        return FormatMarkup(GenerateMarkup(control), GetOrDefaultRules(userRules));
    }

    private static List<(string, string, int)> GenerateMarkup(Control control)
    {
        // объявление списка для хранения разметки.
        // (обозначение атрибута) | (название атрибута) | (индекс вложенности)
        var markupList = new List<(string, string, int)>();
        
        // необходимо вызвать метод для генерации самого контрола и передать в него стартовый контрол.
        GenerateControlMarkup(markupList, control);

        return markupList;
    }

    private static void GenerateControlMarkup(List<(string, string, int)> markupList, Control control, int index = 0)
    {
        // добавляем открывающий тег контрола
        markupList.Add(("head", control.Name, index));
        
        // генерируем атрибуты контрола
        if (control.Children.Content.Count > 0)
        {
            int containerAttribute = -1;
            for (var i = 0; i < control.Attributes.Count; i++)
            {
                if (control.Attributes[i].IsContainer)
                {
                    containerAttribute = i;
                    break;
                }
            }
            if (containerAttribute != -1)
                control.Attributes.RemoveAt(containerAttribute);
        }

        GenerateAttributeMarkup(markupList, control.Attributes);

        // если у контрола есть дочерние элементы, то генерируем их разметку
        if (control.Children is { Content: not null })
        {
            foreach (var child in control.Children.Content)
            {
                GenerateControlMarkup(markupList, child, index + 1);
            }
        }
        
        // добавляем закрывающий тег контрола
        markupList.Add(("head", control.Name, index));
    }
    
    private static void GenerateAttributeMarkup(List<(string, string, int)> markupDictionary, List<Attribute> attributes)
    {
        var level = markupDictionary[^1].Item3 + 1;
        foreach (var attribute in attributes)
        {
            if (string.IsNullOrEmpty(attribute.Value))
                continue;
            
            
            markupDictionary.Add(("attribute", $"{attribute.Name}=\"{attribute.Value}\"", level));
        }
    }

    private static string FormatMarkup(List<(string, string, int)> markupDictionary, Dictionary<string, bool> userRules)
    {
        StringBuilder builder = new StringBuilder();
        
        foreach (var element in markupDictionary)
        {
            string indent = new string(' ', element.Item3 * 4); // 4 пробела на уровень вложенности
            builder.AppendLine($"{indent}({element.Item1}) {element.Item2} [{element.Item3}]");
        }
        
        return builder.ToString();
    }
    
    
    /*public static string GenerateMarkup(
        Control control, 
        bool allowDefaultValues = false,
        bool attributeOnNewLine = false,
        bool useSelfClosingTag = false,
        bool firstAttributeInline = false)
    {
        var markupBuilder = new StringBuilder();
     
        markupBuilder.Append($"<{control.Name}");

        var attributes = control.Attributes;
        if (control.Children is not { Content: null })
            attributes = attributes.Skip(1).ToList();
        
        GenerateAttributeMarkup(markupBuilder, 
            attributes, 
            allowDefaultValues, 
            attributeOnNewLine, 
            firstAttributeInline);

        if (attributeOnNewLine)
            markupBuilder.Append('\n');

        if (useSelfClosingTag && control.Children is { Content: null })
            markupBuilder.Append("/>");
        else if (!useSelfClosingTag && control.Children is { Content: null })
            markupBuilder.Append($"></{control.Name}>");
        else
        {
            markupBuilder.Append(">\n");
            
            GenerateChildrenMarkup(markupBuilder, control);
            
            markupBuilder.Append($"\n</{control.Name}>");
        }
        
        return markupBuilder.ToString();
    }

    private static void GenerateChildrenMarkup(
        StringBuilder markupBuilder,
        Control parent,
        bool allowDefaultValues = false,
        bool attributeOnNewLine = false,
        bool useSelfClosingTag = false,
        bool firstAttributeInline = false)
    {
        markupBuilder.Append($"    <{parent.Name}.{parent.Attributes[0].Name}>\n");

        foreach (var child in parent.Children.Content)
        {
            markupBuilder.Append($"        <{child.Name}");
            
            if (attributeOnNewLine)
                markupBuilder.Append('\n');

            if (useSelfClosingTag && child.Children is { Content: null })
                markupBuilder.Append("        />");
            else if (!useSelfClosingTag && child.Children is { Content: null })
                markupBuilder.Append($"        ></{child.Name}>");
            else
            {
                markupBuilder.Append(">\n");

                markupBuilder.Append("            Есть вложенность");
            
                markupBuilder.Append($"\n        </{child.Name}>");
            }
        }
        
        markupBuilder.Append($"\n    </{parent.Name}.{parent.Attributes[0].Name}>");
    }
    
    private static void GenerateAttributeMarkup(
        StringBuilder markupBuilder, 
        List<Attribute> attributes, 
        bool allowDefaultValues,
        bool attributeOnNewLine,
        bool firstAttributeInline)
    {
        for (var index = 0; index < attributes.Count; index++)
        {
            var attribute = attributes[index].Name;
            var value = attributes[index].Value;
            if (allowDefaultValues)
                value = string.IsNullOrEmpty(value) ? attributes[index].DefaultValue?.ToString() : value;
                
            if (!allowDefaultValues && string.IsNullOrEmpty(value))
            {
                // Skip attributes with no value if not allowing default values
                continue;
            }
            
            if (index == 0 && firstAttributeInline)
                markupBuilder.Append($" {attribute}=\"{value}\"");
            else if (attributeOnNewLine)
                markupBuilder.Append($"\n    {attribute}=\"{value}\"");
            else
                markupBuilder.Append($" {attribute}=\"{value}\"");
        }
    }*/
    
}