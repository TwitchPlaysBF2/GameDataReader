using GameDataReader.BattlefieldRefractorCommon.Parsing;

namespace GameDataReader.BattlefieldRefractorCommon.Files;

/// <summary>
/// Represents a Refractor engine .con configuration file.
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
public abstract class ConfigFile<T>
{
    protected readonly string GameName;

    protected ConfigFile(string gameName)
    {
        GameName = gameName;
    }

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
            throw new FileNotFoundException(
                "Couldn't find configuration data. Is the game installed?\r\n" +
                $"{typeof(T).FullName} not found at location: {filePath}");

        var configLines = File.ReadAllLines(filePath);
        var resolver = new SettingResolver(configLines);
        return resolver;
    }
}