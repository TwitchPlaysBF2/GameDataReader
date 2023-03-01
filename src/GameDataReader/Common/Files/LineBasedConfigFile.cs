using GameDataReader.Common.Parsing;
using System.Text;

namespace GameDataReader.Common.Files;

/// <summary>
/// Represents a line based configuration file (one key-value pair per line).
/// </summary>
/// <typeparam name="T">The type of the config file.</typeparam>
internal abstract class LineBasedConfigFile<T> : IConfigFile
{
    protected abstract string GetParsePattern();
    public abstract string GetFilePath();

    public string GetSettingValue(string settingKey)
    {
        var settingFinder = ReadConfigFile();
        var setting = settingFinder.GetSetting(settingKey);
        var value = setting.GetValue();
        return value;
    }

    public ISettingResolver ReadConfigFile()
    {
        var filePath = GetFilePath();
        if (!File.Exists(filePath))
            throw new FileNotFoundException(
                "Couldn't find configuration data. Is the game installed?\r\n" +
                $"{typeof(T).FullName} not found at location: {filePath}");

        //BF1942 and BFVietnam CON files use ANSI/windows-1252 character encoding
        var configLines = new List<string>();
        if (filePath.ToLower().Contains("bf1942") || filePath.ToLower().Contains("bfvietnam"))
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            configLines = File.ReadAllLines(filePath, Encoding.GetEncoding("windows-1252")).ToList();
        }
        else
        {
            configLines = File.ReadAllLines(filePath).ToList();
        }

        var resolver = new LineBasedSettingResolver(configLines, GetParsePattern());
        return resolver;
    }
}