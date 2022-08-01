namespace GameDataReader.Battlefield1942.Reader;

public class Bf1942Player
{
    public string OnlineName { get; }

    public Bf1942Player(string onlineName)
    {
        OnlineName = onlineName;
    }
}