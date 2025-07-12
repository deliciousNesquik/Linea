using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linea.Core.Interfaces;
using Linea.Core.Models;

namespace Linea.Core.Services;

public class MarkupGenerator : IMarkupGenerator
{
    private readonly IMarkupBuilder _builder;
    private readonly IMarkupFormatter _formatter;
    private readonly IMarkupRules _rules;
    
    public MarkupGenerator(IMarkupBuilder builder, IMarkupFormatter formatter, IMarkupRules rules)
    {
        _builder = builder;
        _formatter = formatter;
        _rules = rules;
    }
    
    public string Generate(Control control, Dictionary<string, bool>? rules = null)
    {
        var markup = _builder.Build(control);
        var mergedRules = _rules.MergeWithDefaults(rules);
        return _formatter.Format(markup, mergedRules);
    }
    
}