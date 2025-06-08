using System.Text.RegularExpressions;
using GameDataReader.Common;
using GameDataReader.Common.Parsing;

namespace GameDataReader.BattlefieldBadCompany2.Parsing;

internal class BinSettingResolver : ISettingResolver
{
    private readonly string _configContent;

    public BinSettingResolver(string configContent)
    {
        _configContent = configContent;
    }

    /// <summary>
    /// Looks up the desired setting in a Bad Company 2 GameSettings.bin configuration file.
    /// </summary>
    public ISetting GetSetting(string settingKey)
    {
        /*
         * Since GameSettings.bin is a binary file, there is lots of unreadable stuff in there. But through all that,
         * a pattern of [key]...stuff...[value] emerges. We need to ignore some keys for which there are no (readable) values,
         * such as FlashValues, UIMenuTrackerPage_Store, UIMenuTrackerPage_MenuUnlocks etc.
         */
        var regex = new Regex($@"(?<{Constants.RegexKeyGroupName}>[a-zA-Z][\w]+)(?<!UIMenu\w+|FlashValues)[\x00-\x1F\x7f-\x9f\u2122\ufffd\s%]+(?<{Constants.RegexValueGroupName}>[\x20-\x7e]+)");
        foreach (Match match in regex.Matches(_configContent))
        {
            var key = match.Groups[Constants.RegexKeyGroupName].Value;
            var value = match.Groups[Constants.RegexValueGroupName].Value;
            
            if (key != settingKey)
                continue;

            return new BinSetting(value);
        }

        throw new GameDataReaderException(message:
            $"Couldn't find config setting: {settingKey}\r\n" +
            "Given config content was:\r\n" +
            _configContent);
    }
}