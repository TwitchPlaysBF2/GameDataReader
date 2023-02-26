using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class ProfileRefractorV1ConfigFile : RefractorConfigFile<ProfileRefractorV1ConfigFile>
{
    private readonly string _modName;
    private readonly string _profileName;
    private readonly string _gameProcessPath;

    public ProfileRefractorV1ConfigFile(string gameName, string modName, string profileName)
        : base(gameName)
    {
        var utilityMethodsRefractorV1 = new UtilityMethodsRefractorV1ConfigFile();
        _modName = modName;
        _profileName = profileName;
        _gameProcessPath = utilityMethodsRefractorV1.GetProcessPath(_modName);
    }

    public override string GetFilePath()
    {
        var generalOptionsFile = $@"\Mods\{ _modName}\Settings\Profiles\{ _profileName}\GeneralOptions.con";
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var filePath = !string.IsNullOrWhiteSpace(_gameProcessPath) ?
            $@"{_gameProcessPath}{generalOptionsFile}" :
            $@"{appData}\VirtualStore\Program Files (x86)\EA GAMES\{GameName}{generalOptionsFile}";
        return filePath;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("game.setPlayerName");
    }
}