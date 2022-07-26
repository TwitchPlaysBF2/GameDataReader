﻿using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V2.Files;

internal class GlobalRefractorV2ConfigFile : RefractorConfigFile<GlobalRefractorV2ConfigFile>
{
    public GlobalRefractorV2ConfigFile(string gameName)
        : base(gameName)
    {
    }

    public override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\{GameName}\Profiles\Global.con";
    }

    /// <summary>
    /// Gets the last logged in player profile number.
    /// Further player configs can be found in a folder which has the name of the players proflie number.   
    /// </summary>
    /// <returns></returns>
    /// <exception cref="GameDataReaderException"></exception>
    public string GetCurrentlyActiveProfileNumber()
    {
        var profileNumber = GetSettingValue("GlobalSettings.setDefaultUser");
        if (!int.TryParse(profileNumber, out _))
            throw new GameDataReaderException(message:
                $"Couldn't parse profile number from config file: {GetFilePath()}" +
                $"Illegal format, expected only numbers in profile number string: {profileNumber}");

        // Don't return int otherwise we lose leading zeros
        return profileNumber;
    }

    /// <summary>
    /// Returns the players currently set clan tag (prefix).
    /// </summary>
    /// <returns></returns>
    /// <exception cref="GameDataReaderException"></exception>
    public string? GetPlayerPrefix()
    {
        var prefix = GetSettingValue("GlobalSettings.setNamePrefix");
        if (string.IsNullOrWhiteSpace(prefix))
            return null;

        return prefix;
    }
}