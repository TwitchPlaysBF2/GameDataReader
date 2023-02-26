using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class GlobalRefractorV1ConfigFile : RefractorConfigFile<GlobalRefractorV1ConfigFile>
{
    private readonly string _modName;
    private readonly string _gameProcessPath;

    public GlobalRefractorV1ConfigFile(string gameName, string modName)
        : base(gameName)
    {
        var utilityMethodsRefractorV1 = new UtilityMethodsRefractorV1ConfigFile();
        _modName = modName;
        _gameProcessPath = utilityMethodsRefractorV1.GetProcessPath(_modName);
    }

    public override string GetFilePath()
    {
        var profileFile = $@"\Mods\{_modName}\Settings\Profile.con";
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var filePath = !string.IsNullOrWhiteSpace(_gameProcessPath) ?
            $@"{_gameProcessPath}{profileFile}" :
            $@"{appData}\VirtualStore\Program Files (x86)\EA GAMES\{GameName}{profileFile}";
        return filePath;
    }

    public string GetCurrentlyActiveProfileName()
    {
        return GetSettingValue("game.setProfile");
    }
}