using GameDataReader.Common.Parsing;

namespace GameDataReader.Common.Files;

internal abstract class ConfigFile
{
    protected abstract string GetFilePath();
    protected abstract string GetSettingValue(string settingKey);
    protected abstract SettingResolver ReadConfigFile();
}