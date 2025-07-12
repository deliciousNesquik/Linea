using System.Collections.Generic;
using Linea.Core.Interfaces;

namespace Linea.Core.Services;

public class MarkupRules : IMarkupRules
{
    public Dictionary<string, bool> MergeWithDefaults(Dictionary<string, bool>? userRules)
    {
        var defaults = new Dictionary<string, bool>
        {
            { "attributeOnNewLine", false },
            { "useSelfClosingTag", false },
            { "firstAttributeInline", true }
        };

        if (userRules is null) return defaults;

        foreach (var rule in userRules)
            defaults[rule.Key] = rule.Value;

        return defaults;
    }
}