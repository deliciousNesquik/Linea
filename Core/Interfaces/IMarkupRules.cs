using System.Collections.Generic;

namespace Linea.Core.Interfaces;

public interface IMarkupRules
{
    public Dictionary<string, bool> MergeWithDefaults(Dictionary<string, bool>? userRules);
}