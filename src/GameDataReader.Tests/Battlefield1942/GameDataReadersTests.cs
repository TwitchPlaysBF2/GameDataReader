using System;
using FluentAssertions;
using GameDataReader.Battlefield1942.Reader;
using NUnit.Framework;

namespace GameDataReader.Tests.Battlefield1942;

public class GameDataReadersTests
{
    private static IBf1942DataReader Bf1942DataReader => new Bf1942DataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = Bf1942DataReader.ReadActivePlayer();

        Console.WriteLine($"Player Name: {player.OnlineName}");
    }

    [Test]
    public void GameDataReaders_Bf1942_IsSingleton()
    {
        var bf1942DataReader1 = GameDataReaders.Bf1942;
        var bf1942DataReader2 = GameDataReaders.Bf1942;

        bf1942DataReader1.GetHashCode().Should()
            .Be(bf1942DataReader2.GetHashCode());
    }

    [Test]
    public void GameDataReaders_GetAccessor_IsNotSingleton()
    {
        var bf1942DataReader1 = Bf1942DataReader;
        var bf1942DataReader2 = Bf1942DataReader;

        bf1942DataReader1.GetHashCode().Should()
            .NotBe(bf1942DataReader2.GetHashCode());
    }
}