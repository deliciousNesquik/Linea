using System;
using System.Collections.Generic;
using System.Text;
using Linea.Core.Enum;
using Linea.Core.Interfaces;

namespace Linea.Core.Services;

public class MarkupFormatter : IMarkupFormatter
{
    public string Format(List<(StructureType Type, string Text, int Level)> markup, Dictionary<string, bool> rules)
    {
        var builder = new StringBuilder();

        bool selfClosing = rules.TryGetValue("useSelfClosingTag", out var val) && val;
        bool attributeOnNewLine = rules.TryGetValue("attributeOnNewLine", out var aNewLine) && aNewLine;
        bool firstAttributeInline = rules.TryGetValue("firstAttributeInline", out var firstInline) && firstInline;
        bool useIndent = rules.TryGetValue("indent", out var useIndentation) && useIndentation;

        bool isOpenTagPending = false;
        string currentTagName = null;
        int currentLevel = 0;
        bool isFirstAttribute = true;

        string GetIndent(int level) => new string(' ', level * 4);

        for (int i = 0; i < markup.Count; i++)
        {
            var (type, text, level) = markup[i];

            if (useIndent && level != currentLevel)
            {
                currentLevel = level;
            }

            switch (type)
            {
                case StructureType.OpenTag:
                    if (isOpenTagPending)
                    {
                        builder.Append('>');
                        isOpenTagPending = false;
                    }

                    if (useIndent)
                        builder.Append(GetIndent(level));

                    builder.Append('<').Append(text);
                    isOpenTagPending = true;
                    currentTagName = text;
                    isFirstAttribute = true;
                    break;

                case StructureType.Attribute:
                    if (attributeOnNewLine && (!firstAttributeInline || !isFirstAttribute))
                    {
                        builder.AppendLine();
                        if (useIndent)
                            builder.Append(GetIndent(level + 1));
                    }
                    else
                    {
                        builder.Append(' ');
                    }

                    builder.Append(text);
                    isFirstAttribute = false;

                    bool nextIsNotAttribute = i + 1 >= markup.Count || markup[i + 1].Type != StructureType.Attribute;
                    if (nextIsNotAttribute)
                    {
                        bool nextIsCloseTag = i + 1 < markup.Count && markup[i + 1].Type == StructureType.CloseTag;
                        bool nextIsSameTag = nextIsCloseTag && markup[i + 1].Text == currentTagName;

                        if (selfClosing && nextIsCloseTag && nextIsSameTag)
                        {
                            builder.Append("/>");
                            isOpenTagPending = false;
                            currentTagName = null;
                            i++; // пропускаем CloseTag
                        }
                        else
                        {
                            builder.Append('>');
                            isOpenTagPending = false;
                        }
                    }
                    break;

                case StructureType.CloseTag:
                    if (isOpenTagPending)
                    {
                        builder.Append('>');
                        isOpenTagPending = false;
                    }

                    if (useIndent)
                        builder.Append(GetIndent(level));

                    if (attributeOnNewLine)
                        builder.AppendLine();
                    builder.Append("</").Append(text).Append('>');
                    break;
            }

            // После закрытия тега — перевод строки
            if (type == StructureType.CloseTag || (type == StructureType.Attribute && i + 1 < markup.Count && markup[i + 1].Type == StructureType.OpenTag) && attributeOnNewLine)
            {
                builder.AppendLine();
            }
        }

        if (isOpenTagPending)
        {
            builder.Append('>');
        }

        return builder.ToString();
    }

}
