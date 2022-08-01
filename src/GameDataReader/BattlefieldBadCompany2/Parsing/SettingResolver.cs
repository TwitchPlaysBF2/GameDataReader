using System.Text.RegularExpressions;

namespace GameDataReader.BattlefieldBadCompany2.Parsing;

/// <summary>
/// Loops through configuration file settings until it finds the right one.
/// </summary>
internal class SettingResolver : Common.Parsing.SettingResolver
{
    private readonly string _configContent;

    public SettingResolver(string configContent)
    {
        _configContent = configContent;
    }

    /// <summary>
    /// Looks up the desired setting in a Bad Company 2 GameSettings.bin configuration file.
    /// </summary>
    public override Common.Parsing.Setting GetSetting(string settingKey)
    {
        /*
         * Since GameSettings.bin is a binary file, there is lots of unreadable stuff in there. But through all that,
         * a pattern of [key]...stuff...[value] emerges. We need to ignore some key for which there no (readable) values,
         * such as FlashValues, UIMenuTrackerPage_Store, UIMenuTrackerPage_MenuUnlocks etc.
         */
        var re = new Regex(@"(?<key>[a-zA-Z][\w]+)(?<!UIMenu\w+|FlashValues)[\x00-\x1F\x7f-\x9f\u2122\ufffd\s]+(?<value>[\x20-\x7e]+)");
        foreach (Match match in re.Matches(_configContent))
        {
            var key = match.Groups["key"].Value;
            var value = match.Groups["value"].Value;
            
            if (key != settingKey)
                continue;

            return new Setting(value);
        }

        throw new GameDataReaderException(message:
            $"Couldn't find config setting: {settingKey}\r\n" +
            "Given config content was:\r\n" +
            _configContent);
    }
}