namespace GameDataReader.Battlefield2.Reader;

public class Bf2Player
{
    public string OnlineName { get; }
    public string? ClanTag { get; }

    public Bf2Player(string onlineName, string? clanTag)
    {
        OnlineName = onlineName;
        ClanTag = clanTag;
    }
}