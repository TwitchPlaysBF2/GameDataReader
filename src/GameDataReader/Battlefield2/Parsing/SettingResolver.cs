namespace GameDataReader.Battlefield2.Parsing;

/// <summary>
/// Loops through configuration file lines until it finds the right one.
/// </summary>
internal class SettingResolver
{
    private readonly IEnumerable<string> _configLines;

    public SettingResolver(IEnumerable<string> configLines)
    {
        _configLines = configLines;
    }

    /// <summary>
    /// Looks up the desired setting in a BF2 .con configuration file.
    /// </summary>
    public Setting GetSetting(string settingKey)
    {
        foreach (var configLine in _configLines)
        {
            if (!configLine.Contains(settingKey))
                continue;

            return new Setting(configLine, settingKey);
        }

        throw new GameDataReaderException(message:
            $"Couldn't find config line: {settingKey}\r\n" +
            "Given config lines were:\r\n" +
            string.Join("\r\n", _configLines));
    }
}