using GameDataReader.BattlefieldBadCompany2.Parsing;
using GameDataReader.Common.Files;
using GameDataReader.Common.Parsing;

namespace GameDataReader.BattlefieldBadCompany2.Files;

internal class BfBc2GameSettingsBinFile : IConfigFile
{
    public string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\BFBC2\GameSettings.bin";
    }

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
                $"{GetType().FullName} not found at location: {filePath}");

        var content = File.ReadAllText(filePath);
        var resolver = new BfBc2GameSettingsBinSettingResolver(content);
        return resolver;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("LastPersona");
    }
}