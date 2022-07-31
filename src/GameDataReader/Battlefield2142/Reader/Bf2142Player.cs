namespace GameDataReader.Battlefield2142.Reader;

public class Bf2142Player
{
    public string OnlineName { get; }
    public string? ClanTag { get; }

    public Bf2142Player(string onlineName, string? clanTag)
    {
        OnlineName = onlineName;
        ClanTag = clanTag;
    }
}