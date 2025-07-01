using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Linea.Core.Interface;

namespace Linea.Core.Services;

public class LocalizationService: ILocalizationService
{
    private Dictionary<string, string> _translations = new();
    
    public bool LoadLocalization(string localeFilename)
    {
        if (!File.Exists(localeFilename))
            return false;

        var json = File.ReadAllText(localeFilename);
        _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                        ?? new Dictionary<string, string>();
        return true;
    }

    public string Translate(string key)
    {
        return _translations.GetValueOrDefault(key, key);
    }

    public bool UnloadLocalization()
    {
        _translations.Clear();
        _translations = null!;
        
        return _translations is null;
    }
}