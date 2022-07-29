using GameDataReader.Battlefield2.Reader;

namespace GameDataReader;

public static class GameDataReaders
{
    private static readonly Lazy<IBf2DataReader> Bf2Singleton = new(() => new Bf2DataReader());

    public static IBf2DataReader Bf2 => Bf2Singleton.Value;
}