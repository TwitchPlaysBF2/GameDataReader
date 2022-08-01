﻿using System.Text.RegularExpressions;

namespace GameDataReader.Common.Parsing;

/// <summary>
/// Represents a line inside of line based configuration file.
/// </summary>
internal class LineBasedSetting : Setting
{
    private readonly string _configLine;
    private readonly string _settingKey;
    private readonly string _parsePattern;

    public LineBasedSetting(string configLine, string settingKey, string parsePattern)
    {
        if (string.IsNullOrWhiteSpace(configLine) || string.IsNullOrWhiteSpace(settingKey))
            throw new GameDataReaderException(
                $"Failed to identify setting '{settingKey}' from configuration line: '{configLine}'");

        _configLine = configLine;
        _settingKey = settingKey;
        _parsePattern = parsePattern;
    }

    public override string ParseValue()
    {
        var re = new Regex(_parsePattern);
        var match = re.Match(_configLine);
        
        if (!match.Success || match.Groups["key"].Value != _settingKey)
            throw new GameDataReaderException(
                $"The setting {_settingKey} could not be parsed correctly. Key not found in config line:\r\n{_configLine}");

        return match.Groups["value"].Value.Trim();
    }
}