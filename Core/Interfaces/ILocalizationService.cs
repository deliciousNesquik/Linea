namespace Linea.Core.Interface;

public interface ILocalizationService
{
    /// <summary>
    /// Пытается загрузить файл локализации по указанному пути.
    /// </summary>
    /// <code>
    ///var service = new LocalizationService();
    ///service.LoadLocalization("localization.ru.json");
    /// </code>
    /// <param name="localeFilename">Полный путь к файлу локализации JSON (например, localization.en.json).</param>
    /// <returns><b>true</b> - если файл локализации был успешно загружен и проанализирован. <b>false</b> - если файл не существует, недействителен или не может быть проанализирован.</returns>
    bool LoadLocalization(string localeFilename);
    
    /// <summary>
    /// Возвращает локализованную строку, соответствующую указанному ключу.
    /// </summary>
    /// <param name="key">Akey — строковый идентификатор (например, "Button. Content"),
    /// по которому выполняется поиск перевода в загруженном файле локализации.</param>
    /// <returns>Переведённую строку, соответствующую ключу, если такой ключ найден в текущем словаре локализации.
    ///Если ключ не найден, возвращается сам ключ в качестве запасного варианта.</returns>
    /// <remarks>Метод используется во всём интерфейсе приложения для отображения текстов,
    /// соответствующих выбранному языку локализации. Это позволяет централизованно управлять
    /// переводами и легко переключать язык без изменения кода пользовательского интерфейса.</remarks>
    /// <code>var service = new LocalizationService();
    ///service.LoadLocalization("localization.ru.json");
    /// 
    ///string buttonText = service.Translate("Button.Content");
    ///Console.WriteLine(buttonText); // Результат: "Текст, отображаемый внутри кнопки"
    ///</code>
    string Translate(string key);

    /// <summary>
    /// Выгружает текущую локализацию и освобождает связанные с ней ресурсы.
    /// Очищает внутренние словари переводов, подготавливая сервис к загрузке новой локализации.
    /// </summary>
    /// <code>
    ///var service = new LocalizationService();
    ///service.LoadLocalization("localization.ru.json");
    /// 
    ///string buttonText = service.Translate("Button.Content");
    ///Console.WriteLine(buttonText);
    ///
    /// 
    ///service.UnloadLocalization(); //Освобождаем ресурсы в случае когда доступ к переводу уже не нужен
    /// </code>
    bool UnloadLocalization();
}