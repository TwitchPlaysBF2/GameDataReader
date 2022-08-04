using GameDataReader.BattlefieldBadCompany2.Files;

namespace GameDataReader.BattlefieldBadCompany2.Reader;

/// <summary>
/// Provides read access to parsed config data from the game folder.
/// </summary>
public class BfBc2DataReader : IBfBc2DataReader
{
    private readonly BfBc2BinFile _bfBc2BinFile;
    private readonly BfBc2IniFile _bfBc2IniFile;

    public BfBc2DataReader()
    {
        _bfBc2BinFile = new BfBc2BinFile();
        _bfBc2IniFile = new BfBc2IniFile();
    }

    /// <summary>
    /// Looks up the stored LastPersona within in the GameSettings.bin file.
    /// </summary>
    /// <returns>Returns the name, if found. Throws an exception, if there was an error.</returns>
    /// <exception cref="FileNotFoundException">If game is not installed.</exception>
    /// <exception cref="GameDataReaderException">If there was a problem while reading the game data.</exception>
    public BfBc2Player ReadActivePlayer()
    {
        var playerName = _bfBc2BinFile.GetPlayerName();
        var playerPrefix = _bfBc2IniFile.GetPlayerPrefix();

        return new BfBc2Player(playerName, playerPrefix);
    }
}