using GameDataReader.Battlefield1942.Reader;
using GameDataReader.Battlefield2.Reader;

namespace GameDataReader;

public static class GameDataReaders
{
    private static readonly Lazy<IBf1942DataReader> Bf1942Singleton = new(() => new Bf1942DataReader());
    private static readonly Lazy<IBf2DataReader> Bf2Singleton = new(() => new Bf2DataReader());

    public static IBf1942DataReader Bf1942 => Bf1942Singleton.Value;
    public static IBf2DataReader Bf2 => Bf2Singleton.Value;
}