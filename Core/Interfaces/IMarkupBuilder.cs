using System.Collections.Generic;
using Linea.Core.Enum;
using Linea.Core.Models;

namespace Linea.Core.Interfaces;

public interface IMarkupBuilder
{
    List<(StructureType Type, string Text, int Level)> Build(Control control);
}