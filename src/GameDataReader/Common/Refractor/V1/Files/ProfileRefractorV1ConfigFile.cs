using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class ProfileRefractorV1ConfigFile : RefractorConfigFile<ProfileRefractorV1ConfigFile>
{
    private readonly string _modName;
    private readonly string _profileName;
    private readonly string _gameProcessPath;
    private readonly string _conFilePath;

    public ProfileRefractorV1ConfigFile(string gameName, string modName, string profileName)
        : base(gameName)
    {
        var utilityMethodsRefractorV1 = new UtilityMethodsRefractorV1ConfigFile();
        _modName = modName;
        _profileName = profileName;
        _gameProcessPath = utilityMethodsRefractorV1.GetProcessPath(_modName);
        var conFile = $@"\Mods\{_modName}\Settings\Profiles\{_profileName}\GeneralOptions.con";
        _conFilePath = utilityMethodsRefractorV1.GetConFilePath(conFile, _gameProcessPath, GameName);
    }

    public override string GetFilePath()
    {
        return _conFilePath;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("game.setPlayerName");
    }
}