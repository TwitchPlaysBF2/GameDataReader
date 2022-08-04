namespace GameDataReader.Common.Parsing;

/// <summary>
/// Loops through configuration file lines until it finds the right one.
/// </summary>
internal class LineBasedSettingResolver : ISettingResolver
{
    private readonly IEnumerable<string> _configLines;
    private readonly string _parsePattern;

    public LineBasedSettingResolver(IEnumerable<string> configLines, string parsePattern)
    {
        _configLines = configLines;
        _parsePattern = parsePattern;
    }

    /// <summary>
    /// Looks up the desired setting in a line-based configuration file.
    /// </summary>
    public ISetting GetSetting(string settingKey)
    {
        foreach (var configLine in _configLines)
        {
            if (!configLine.Contains(settingKey))
                continue;

            return new LineBasedSetting(configLine, settingKey, _parsePattern);
        }

        throw new GameDataReaderException(message:
            $"Couldn't find config line: {settingKey}\r\n" +
            "Given config lines were:\r\n" +
            string.Join("\r\n", _configLines));
    }
}