using GameDataReader.Battlefield1942.Reader;
using GameDataReader.Battlefield2.Reader;
using GameDataReader.BattlefieldVietnam.Reader;

namespace GameDataReader;

public static class GameDataReaders
{
    private static readonly Lazy<IBf1942DataReader> Bf1942Singleton = new(() => new Bf1942DataReader());
    private static readonly Lazy<IBfVietnamDataReader> BfVietnamSingleton = new(() => new BfVietnamDataReader());
    private static readonly Lazy<IBf2DataReader> Bf2Singleton = new(() => new Bf2DataReader());

    public static IBfVietnamDataReader BfVietnam => BfVietnamSingleton.Value;
    public static IBf1942DataReader Bf1942 => Bf1942Singleton.Value;
    public static IBf2DataReader Bf2 => Bf2Singleton.Value;
}