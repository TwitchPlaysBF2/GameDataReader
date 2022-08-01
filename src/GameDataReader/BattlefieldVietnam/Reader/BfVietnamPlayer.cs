namespace GameDataReader.BattlefieldVietnam.Reader;

public class BfVietnamPlayer
{
    public string OnlineName { get; }

    public BfVietnamPlayer(string onlineName)
    {
        OnlineName = onlineName;
    }
}