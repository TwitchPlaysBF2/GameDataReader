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

    protected override string GetFilePath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return $@"{appData}\VirtualStore\Program Files (x86)\EA GAMES\{GameName}\Mods\{_modName}\Settings\Profile.con";
    }

    public string GetCurrentlyActiveProfileName()
    {
        return GetSettingValue("game.setProfile");
    }
}