using GameDataReader.Common.Refractor.V2.Files;

namespace GameDataReader.Battlefield2.Reader;

/// <summary>
/// Provides read access to parsed config data from the BF2 folder.
/// </summary>
public class Bf2DataReader : IBf2DataReader
{
    private const string GameName = "Battlefield 2";
    private const string NameSettingKey = "LocalProfile.setGamespyNick";
    private readonly GlobalRefractorV2ConfigFile _globalConfig;
    private ProfileRefractorV2ConfigFile? _profileConfig;

    public Bf2DataReader()
    {
        _globalConfig = new GlobalRefractorV2ConfigFile(GameName);
    }

    /// <summary>
    /// Looks up the last logged in player profile through the Global.con file.
    /// Then reads the stored GamespyNick within the according Profile.con file.
    /// </summary>
    /// <returns>Returns the name, if found. Throws an exception, if there was an error.</returns>
    /// <exception cref="FileNotFoundException">If game is not installed.</exception>
    /// <exception cref="GameDataReaderException">If there was a problem while reading the game data.</exception>
    public Bf2Player ReadActivePlayer()
    {
        var activeProfileNumber = _globalConfig.GetCurrentlyActiveProfileNumber();
        _profileConfig = new ProfileRefractorV2ConfigFile(GameName, activeProfileNumber, NameSettingKey);
        var playerName = _profileConfig.GetPlayerName();
        var playerPrefix = _globalConfig.GetPlayerPrefix();

        return new Bf2Player(playerName, playerPrefix);
    }
}