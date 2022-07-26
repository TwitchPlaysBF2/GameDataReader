namespace GameDataReader.Battlefield2.Files;

internal class ProfileBf2ConfigFile : Bf2ConfigFile<ProfileBf2ConfigFile>
{
    private readonly string _profileNumber;

    public ProfileBf2ConfigFile(string profileNumber)
    {
        _profileNumber = profileNumber;
    }

    protected override string GetFilePath()
    {
        var userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return $@"{userDocuments}\Battlefield 2\Profiles\{_profileNumber}\Profile.con";
    }

    public string GetPlayerName()
    {
        return GetSettingValue("LocalProfile.setGamespyNick");
    }
}