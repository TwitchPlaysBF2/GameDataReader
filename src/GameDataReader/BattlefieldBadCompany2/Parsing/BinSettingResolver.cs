using System.Text;
using GameDataReader.Common.Parsing;

namespace GameDataReader.BattlefieldBadCompany2.Parsing;

internal class BinSettingResolver : ISettingResolver
{
    private readonly byte[] _configContent;

    public BinSettingResolver(byte[] configContent)
    {
        _configContent = configContent;
    }

    /// <summary>
    /// Looks up the desired setting in a Bad Company 2 GameSettings.bin configuration file.
    /// </summary>
    public ISetting GetSetting(string settingKey)
    {
        var stream = new MemoryStream(_configContent);
        var reader = new BinaryReader(stream);

        // File content is split into sections, which can and will be empty
        while (reader.BaseStream.Length - reader.BaseStream.Position >= 4)
        {
            // Each section starts with a 4-byte integer indicating the number of contained key-value pairs
            var n = reader.ReadUInt32();

            for (var i = 0; i < n; i++)
            {
                // Every key-value pair is prefixed with what seems to be a value type indicator
                // 1 = float
                // 2 = integer (signed)
                // 3 = string
                reader.ReadUInt32();

                // Both key and value are stored as pascal strings regardless of the indicated type
                var key = ReadPascalString(reader);
                var value = ReadPascalString(reader);
                
                if (key != settingKey)
                    continue;

                return new BinSetting(value);
            }
        }

        throw new GameDataReaderException(message:
            $"Couldn't find config setting: {settingKey}\r\n" +
            "Given config content was:\r\n" +
            Encoding.UTF8.GetString(_configContent));
    }

    private static string ReadPascalString(BinaryReader reader)
    {
        var length = reader.ReadUInt32();
        var bytes = reader.ReadBytes((int)length);
        if (bytes.Length != length)
        {
            throw new EndOfStreamException("Unexpected EOF while reading Pascal string");
        }
        
        return Encoding.UTF8.GetString(bytes, 0, (int)(length - 1));
    }
}