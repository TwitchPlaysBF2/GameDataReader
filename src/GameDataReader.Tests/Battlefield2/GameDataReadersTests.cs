using System;
using FluentAssertions;
using GameDataReader.Battlefield2.Reader;
using NUnit.Framework;

namespace GameDataReader.Tests.Battlefield2;

public class GameDataReadersTests
{
    private static IBf2DataReader Bf2DataReader => new Bf2DataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = Bf2DataReader.ReadActivePlayer();

        Console.WriteLine($"Player Name: {player.OnlineName}");
        Console.WriteLine($"Prefix: {player.ClanTag}");
    }

    [Test]
    public void GameDataReaders_Bf2_IsSingleton()
    {
        var bf2DataReader1 = GameDataReaders.Bf2;
        var bf2DataReader2 = GameDataReaders.Bf2;

        bf2DataReader1.GetHashCode().Should()
            .Be(bf2DataReader2.GetHashCode());
    }

    [Test]
    public void GameDataReaders_GetAccessor_IsNotSingleton()
    {
        var bf2DataReader1 = Bf2DataReader;
        var bf2DataReader2 = Bf2DataReader;

        bf2DataReader1.GetHashCode().Should()
            .NotBe(bf2DataReader2.GetHashCode());
    }
}