using GameDataReader.BattlefieldRefractorCommon.Files;

namespace GameDataReader.BattlefieldRefractorV1Common.Files;

public class ProfileRefractorV1ConfigFile : Bf2ConfigFile<ProfileRefractorV1ConfigFile>
{
    private readonly string _gameName, _modName, _profileName;

    public ProfileRefractorV1ConfigFile(string gameName, string modName, string profileName)
    {
        _gameName = gameName;
        _modName = modName;
        _profileName = profileName;
    }

    protected override string GetFilePath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return $@"{appData}\VirtualStore\Program Files (x86)\EA GAMES\{_gameName}\Mods\{_modName}\Settings\Profiles\{_profileName}\GeneralOptions.con";
    }

    public string GetPlayerName()
    {
        return GetSettingValue("game.setPlayerName");
    }
}