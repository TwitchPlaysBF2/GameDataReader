using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class GlobalRefractorV1ConfigFile : RefractorConfigFile<GlobalRefractorV1ConfigFile>
{
    private readonly string _modName;
    private readonly string _gameProcessPath;
    private readonly string _conFilePath;

    public GlobalRefractorV1ConfigFile(string gameName, string modName)
        : base(gameName)
    {
        var utilityMethodsRefractorV1 = new UtilityMethodsRefractorV1ConfigFile();
        _modName = modName;
        _gameProcessPath = utilityMethodsRefractorV1.GetProcessPath(_modName);
        var conFile = $@"\Mods\{_modName}\Settings\Profile.con";
        _conFilePath = utilityMethodsRefractorV1.GetConFilePath(conFile, _gameProcessPath, GameName);
    }

    public override string GetFilePath()
    {
        return _conFilePath;
    }

    public string GetCurrentlyActiveProfileName()
    {
        return GetSettingValue("game.setProfile");
    }
}