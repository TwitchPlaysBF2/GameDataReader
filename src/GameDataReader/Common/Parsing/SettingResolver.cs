namespace GameDataReader.Common.Parsing;

internal abstract class SettingResolver
{
    public abstract Setting GetSetting(string settingKey);
}