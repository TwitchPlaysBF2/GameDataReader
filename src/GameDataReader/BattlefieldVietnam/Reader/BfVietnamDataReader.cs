using GameDataReader.Common.Refractor.V1.Files;

namespace GameDataReader.BattlefieldVietnam.Reader;

/// <summary>
/// Provides read access to parsed config data from the BF2 folder.
/// </summary>
public class BfVietnamDataReader : IBfVietnamDataReader
{
    private const string GameName = "Battlefield Vietnam";
    private const string ModName = "BfVietnam";
    private readonly GlobalRefractorV1ConfigFile _globalConfig;
    private ProfileRefractorV1ConfigFile? _profileConfig;

    public BfVietnamDataReader()
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
    public BfVietnamPlayer ReadActivePlayer()
    {
        var activeProfileName = _globalConfig.GetCurrentlyActiveProfileName();
        _profileConfig = new ProfileRefractorV1ConfigFile(GameName, ModName, activeProfileName);
        var playerName = _profileConfig.GetPlayerName();

        return new BfVietnamPlayer(playerName);
    }
}