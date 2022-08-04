using GameDataReader.Common;
using GameDataReader.Common.Files;

namespace GameDataReader.BattlefieldBadCompany2.Files;

internal class BfBc2GameSettingsIniFile : LineBasedConfigFile<BfBc2GameSettingsIniFile>
{
    public override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\BFBC2\GameSettings.ini";
    }

    protected override string GetParsePattern()
    {
        // Ignoring the file structure, simply match i.e. VoipEnable=1
        return $@"^(?<{Constants.RegexKeyGroupName}>.*?)=(?<{Constants.RegexValueGroupName}>.*?)$";
    }

    /// <summary>
    /// Returns the players currently set clan tag (prefix).
    /// </summary>
    /// <returns></returns>
    /// <exception cref="GameDataReaderException"></exception>
    public string? GetPlayerPrefix()
    {
        var prefix = GetSettingValue("ClanTag");
        if (string.IsNullOrWhiteSpace(prefix))
            return null;

        return prefix;
    }
}