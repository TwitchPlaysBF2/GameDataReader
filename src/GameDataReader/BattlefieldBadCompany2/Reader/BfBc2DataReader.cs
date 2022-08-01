using GameDataReader.BattlefieldBadCompany2.Files;

namespace GameDataReader.BattlefieldBadCompany2.Reader;

/// <summary>
/// Provides read access to parsed config data from the BF2 folder.
/// </summary>
public class BfBc2DataReader : IBfBc2DataReader
{
    private readonly BfBc2GameSettingsBinFile _gameSettingsBin;
    private readonly BfBc2GameSettingsIniFile _gameSettingsIni;

    public BfBc2DataReader()
    {
        _gameSettingsBin = new BfBc2GameSettingsBinFile();
        _gameSettingsIni = new BfBc2GameSettingsIniFile();
    }

    /// <summary>
    /// Looks up the stored LastPersona within in the GameSettings.bin file.
    /// </summary>
    /// <returns>Returns the name, if found. Throws an exception, if there was an error.</returns>
    /// <exception cref="FileNotFoundException">If game is not installed.</exception>
    /// <exception cref="GameDataReaderException">If there was a problem while reading the game data.</exception>
    public BfBc2Player ReadActivePlayer()
    {
        var playerName = _gameSettingsBin.GetPlayerName();
        var playerPrefix = _gameSettingsIni.GetPlayerPrefix();

        return new BfBc2Player(playerName, playerPrefix);
    }
}