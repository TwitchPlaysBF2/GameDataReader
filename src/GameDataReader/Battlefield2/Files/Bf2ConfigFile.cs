using GameDataReader.Battlefield2.Parsing;

namespace GameDataReader.Battlefield2.Files;

/// <summary>
/// Represents a BF2 .con configuration file.
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
internal abstract class Bf2ConfigFile<T>
{
    protected abstract string GetFilePath();

    protected string GetSettingValue(string settingKey)
    {
        var settingFinder = ReadConfigFile();
        var setting = settingFinder.GetSetting(settingKey);
        var value = setting.ParseValue();
        return value;
    }

    private SettingResolver ReadConfigFile()
    {
        var filePath = GetFilePath();
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Couldn't find {typeof(T).FullName} at location: {filePath}");

        var configLines = File.ReadAllLines(filePath);
        var resolver = new SettingResolver(configLines);
        return resolver;
    }
}