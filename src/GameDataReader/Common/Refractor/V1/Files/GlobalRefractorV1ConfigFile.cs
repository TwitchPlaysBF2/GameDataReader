using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class GlobalRefractorV1ConfigFile : RefractorConfigFile<GlobalRefractorV1ConfigFile>
{
    private readonly string _modName;

    public GlobalRefractorV1ConfigFile(string gameName, string modName)
        : base(gameName)
    {
        _modName = modName;
    }

    public override string GetFilePath()
    {
        var conFile = $@"\Mods\{_modName}\Settings\Profile.con";
        conFile = RefractorV1PathResolver.GetConFilePath(conFile, _modName, GameName);
        return conFile;
    }

    public string GetCurrentlyActiveProfileName()
    {
        return GetSettingValue("game.setProfile");
    }
}