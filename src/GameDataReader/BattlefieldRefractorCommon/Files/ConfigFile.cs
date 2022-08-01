using GameDataReader.Common.Files;

namespace GameDataReader.BattlefieldRefractorCommon.Files;

/// <summary>
/// Represents a Refractor engine .con configuration file.
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
internal abstract class ConfigFile<T> : LineBasedConfigFile<T>
{
    protected readonly string GameName;

    protected ConfigFile(string gameName)
    {
        GameName = gameName;
    }

    protected override string GetParsePattern()
    {
        return "^(?<key>.*?) \"?(?<value>.*?)\"?$";
    }
}