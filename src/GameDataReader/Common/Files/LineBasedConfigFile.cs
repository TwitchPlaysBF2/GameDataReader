using GameDataReader.Common.Parsing;

namespace GameDataReader.Common.Files;

/// <summary>
/// Represents a line based configuration file (one key-value pair per line).
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
internal abstract class LineBasedConfigFile<T> : ConfigFile
{
    protected abstract string GetParsePattern();

    protected override string GetSettingValue(string settingKey)
    {
        var settingFinder = ReadConfigFile();
        var setting = settingFinder.GetSetting(settingKey);
        var value = setting.GetValue();
        return value;
    }

    protected override SettingResolver ReadConfigFile()
    {
        var filePath = GetFilePath();
        if (!File.Exists(filePath))
            throw new FileNotFoundException(
                "Couldn't find configuration data. Is the game installed?\r\n" +
                $"{typeof(T).FullName} not found at location: {filePath}");

        var configLines = File.ReadAllLines(filePath);
        var resolver = new LineBasedSettingResolver(configLines, GetParsePattern());
        return resolver;
    }
}