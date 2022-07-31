using GameDataReader.BattlefieldRefractorV1Common.Files;

namespace GameDataReader.Battlefield1942.Reader;

/// <summary>
/// Provides read access to parsed config data from the BF2 folder.
/// </summary>
public class Bf1942DataReader : IBf1942DataReader
{
    private const string GameName = "Battlefield 1942", ModName = "bf1942";
    private readonly GlobalRefractorV1ConfigFile _globalConfig;
    private ProfileRefractorV1ConfigFile? _profileConfig;

    public Bf1942DataReader()
    {
        _globalConfig = new GlobalRefractorV1ConfigFile(GameName, ModName);
    }

    /// <summary>
    /// Looks up the last used player profile through the Profile.con file.
    /// Then reads the stored player name within the according GeneralOptions.con file.
    /// </summary>
    /// <returns>Returns the name, if found. Throws an exception, if there was an error.</returns>
    /// <exception cref="FileNotFoundException">If game is not installed.</exception>
    /// <exception cref="GameDataReaderException">If there was a problem while reading the game data.</exception>
    public Bf1942Player ReadActivePlayer()
    {
        var activeProfileName = _globalConfig.GetCurrentlyActiveProfileName();
        _profileConfig = new ProfileRefractorV1ConfigFile(GameName, ModName, activeProfileName);
        var playerName = _profileConfig.GetPlayerName();

        return new Bf1942Player(playerName);
    }
}