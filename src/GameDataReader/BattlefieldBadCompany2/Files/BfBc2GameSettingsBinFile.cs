using GameDataReader.BattlefieldBadCompany2.Parsing;
using GameDataReader.Common.Files;

namespace GameDataReader.BattlefieldBadCompany2.Files;

internal class BfBc2GameSettingsBinFile : ConfigFile
{
    protected override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\BFBC2\GameSettings.bin";
    }

    protected override string GetSettingValue(string settingKey)
    {
        var settingFinder = ReadConfigFile();
        var setting = settingFinder.GetSetting(settingKey);
        var value = setting.ParseValue();
        return value;
    }

    protected override Common.Parsing.SettingResolver ReadConfigFile()
    {
        var filePath = GetFilePath();
        if (!File.Exists(filePath))
            throw new FileNotFoundException(
                "Couldn't find configuration data. Is the game installed?\r\n" +
                $"{GetType().FullName} not found at location: {filePath}");

        var content = File.ReadAllText(filePath);
        var resolver = new SettingResolver(content);
        return resolver;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("LastPersona");
    }
}