namespace GameDataReader.BattlefieldBadCompany2.Reader;

public class BfBc2Player
{
    public string OnlineName { get; }
    public string? ClanTag { get;  }
    
    public BfBc2Player(string onlineName, string? clanTag)
    {
        OnlineName = onlineName;
        ClanTag = clanTag;
    }
}