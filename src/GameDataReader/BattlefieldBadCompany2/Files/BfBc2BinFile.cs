using GameDataReader.BattlefieldBadCompany2.Parsing;
using GameDataReader.Common.Files;
using GameDataReader.Common.Parsing;

namespace GameDataReader.BattlefieldBadCompany2.Files;

internal class BfBc2BinFile : IConfigFile
{
    private static readonly byte[] Header = { 0x08, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x0d, 0x00, 0x00, 0x00 };
    
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

        // Open file in a way that allows the game to have the file open at the same time
        var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);;
        var reader = new BinaryReader(stream);
        
        // First 12 header bytes seem static
        var header = reader.ReadBytes(12);
        if (header.Equals(Header))
        {
            throw new GameDataReaderException(message:
                $"Invalid file header: {BitConverter.ToString(header).Replace("-", " ").ToLower()}");
        }
        
        // Next 4 bytes indicate the file content length
        var length = reader.ReadInt32();
        var content = reader.ReadBytes(length);
        if (content.Length != length)
        {
            throw new GameDataReaderException(message:
                $"Expected file to have {length} bytes, got {content.Length}");
        }
        
        var resolver = new BinSettingResolver(content);
        return resolver;
    }

    public string GetPlayerName()
    {
        return GetSettingValue("LastPersona");
    }
}