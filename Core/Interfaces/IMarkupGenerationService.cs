using System.Collections.Generic;
using System.Reflection;

namespace Linea.Core.Interfaces;

public interface IMarkupGenerationService
{
    public static abstract string Generate(Models.Control control, Dictionary<string, bool>? userRules = null);
}