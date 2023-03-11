using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class ProfileRefractorV1ConfigFile : RefractorConfigFile<ProfileRefractorV1ConfigFile>
{
    private readonly string _modName;
    private readonly string _profileName;

    public ProfileRefractorV1ConfigFile(string gameName, string modName, string profileName)
        : base(gameName)
    {
        _modName = modName;
        _profileName = profileName;
    }

    public override string GetFilePath()
    {
        var conFile = $@"\Mods\{_modName}\Settings\Profiles\{_profileName}\GeneralOptions.con";
        conFile = RefractorV1PathResolver.GetConFilePath(conFile, _modName, GameName);
        return conFile;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("game.setPlayerName");
    }
}