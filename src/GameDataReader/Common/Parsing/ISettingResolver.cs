namespace GameDataReader.Common.Parsing;

internal interface ISettingResolver
{
    ISetting GetSetting(string settingKey);
}