using System.Collections.Generic;
using Linea.Core.Enum;

namespace Linea.Core.Interfaces;

public interface IMarkupFormatter
{
    string Format(List<(StructureType Type, string Text, int Level)> markup, Dictionary<string, bool> rules);
}