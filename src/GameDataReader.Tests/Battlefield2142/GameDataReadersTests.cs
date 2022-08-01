using System;
using FluentAssertions;
using GameDataReader.Battlefield2.Reader;
using GameDataReader.Battlefield2142.Reader;
using NUnit.Framework;

namespace GameDataReader.Tests.Battlefield2142;

public class GameDataReadersTests
{
    private static IBf2142DataReader Bf2142DataReader => new Bf2142DataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = Bf2142DataReader.ReadActivePlayer();

        Console.WriteLine($"Player Name: {player.OnlineName}");
        Console.WriteLine($"Prefix: {player.ClanTag}");
    }

    [Test]
    public void GameDataReaders_Bf2142_IsSingleton()
    {
        var bf2142DataReader1 = GameDataReaders.Bf2142;
        var bf2142DataReader2 = GameDataReaders.Bf2142;

        bf2142DataReader1.GetHashCode().Should()
            .Be(bf2142DataReader2.GetHashCode());
    }

    [Test]
    public void GameDataReaders_GetAccessor_IsNotSingleton()
    {
        var bf2142DataReader1 = Bf2142DataReader;
        var bf2142DataReader2 = Bf2142DataReader;

        bf2142DataReader1.GetHashCode().Should()
            .NotBe(bf2142DataReader2.GetHashCode());
    }
}