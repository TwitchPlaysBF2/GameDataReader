using GameDataReader.Common.Parsing;

namespace GameDataReader.Common.Files;

internal interface IConfigFile
{
    string GetFilePath();
    string GetSettingValue(string settingKey);
    ISettingResolver ReadConfigFile();
}