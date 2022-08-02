using GameDataReader.Common.Files;

namespace GameDataReader.Common.Refractor.Files;

/// <summary>
/// Represents a Refractor engine .con configuration file.
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
internal abstract class RefractorConfigFile<T> : LineBasedConfigFile<T>
{
    protected readonly string GameName;

    protected RefractorConfigFile(string gameName)
    {
        GameName = gameName;
    }

    protected override string GetParsePattern()
    {
        return "^(?<key>.*?) \"?(?<value>.*?)\"?$";
    }
}