using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Linea.Core.Models;

namespace Linea.Core.Interfaces;

public interface IControlMetadataService
{
    /// <summary>
    /// Загружает список UI-контролов из указанного JSON-файла.
    /// </summary>
    /// <param name="path">Путь к JSON-файлу, содержащему описание контролов.</param>
    /// <returns>Список объектов <see cref="Control"/>, считанных из файла.</returns>
    /// <exception cref="FileNotFoundException">Файл по указанному пути не найден.</exception>
    /// <exception cref="JsonException">Ошибка разбора JSON-файла.</exception>
    /// <exception cref="InvalidOperationException">Не удалось десериализовать данные в список контролов.</exception>
    public static abstract List<Control> LoadControls(string path);
}