namespace GameDataReader.Battlefield2.Parsing;

/// <summary>
/// Represents a line inside of a .con configuration file.
/// </summary>
internal class Setting
{
    private readonly string _configLine;
    private readonly string _settingKey;

    /// <param name="configLine">i.e. LocalProfile.setGamespyNick "TwitchPlaysBF2"</param>
    /// <param name="settingKey">i.e. LocalProfile.setGamespyNick</param>
    public Setting(string configLine, string settingKey)
    {
        if (string.IsNullOrWhiteSpace(configLine) || string.IsNullOrWhiteSpace(settingKey))
            throw new GameDataReaderException(
                $"Failed to identify setting '{settingKey}' from configuration line: '{configLine}'");

        _configLine = configLine;
        _settingKey = settingKey;
    }

    /// <summary>
    /// Removes the key & other fuzz from a config line and returns only the value.
    /// A config line might look like: LocalProfile.setGamespyNick "TwitchPlaysBF2"
    /// </summary>
    /// <returns></returns>
    public string ParseValue()
    {
        if (!_configLine.Contains(_settingKey))
            throw new GameDataReaderException(
                $"The setting {_settingKey} could not be parsed correctly. Key not found in config line:\r\n{_configLine}");

        var value = _configLine
            .Replace(_settingKey, "")
            // Note: This type of parsing swallows apostrophes from the setting. RegEx could fix this.
            .Replace("\"", "")
            .Trim();

        return value;
    }
}