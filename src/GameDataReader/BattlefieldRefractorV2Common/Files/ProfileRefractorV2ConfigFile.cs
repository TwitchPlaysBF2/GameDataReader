using GameDataReader.BattlefieldRefractorCommon.Files;

namespace GameDataReader.BattlefieldRefractorV2Common.Files;

internal class ProfileRefractorV2ConfigFile : ConfigFile<ProfileRefractorV2ConfigFile>
{
    private readonly string _gameName, _profileNumber, _nameSettingKey;

    public ProfileRefractorV2ConfigFile(string gameName, string profileNumber, string nameSettingKey)
    {
        _gameName = gameName;
        _profileNumber = profileNumber;
        _nameSettingKey = nameSettingKey;
    }

    protected override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\{_gameName}\Profiles\{_profileNumber}\Profile.con";
    }

    public string GetPlayerName()
    {
        return GetSettingValue(_nameSettingKey);
    }
}