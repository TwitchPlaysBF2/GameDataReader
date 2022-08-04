using GameDataReader.Common.Refractor.Files;

namespace GameDataReader.Common.Refractor.V2.Files;

internal class ProfileRefractorV2ConfigFile : RefractorConfigFile<ProfileRefractorV2ConfigFile>
{
    private readonly string _profileNumber;
    private readonly string _nameSettingKey;

    public ProfileRefractorV2ConfigFile(string gameName, string profileNumber, string nameSettingKey)
        : base(gameName)
    {
        _profileNumber = profileNumber;
        _nameSettingKey = nameSettingKey;
    }

    public override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\{GameName}\Profiles\{_profileNumber}\Profile.con";
    }

    public string GetPlayerName()
    {
        return GetSettingValue(_nameSettingKey);
    }
}