using System;
using FluentAssertions;
using GameDataReader.BattlefieldVietnam.Reader;
using NUnit.Framework;

namespace GameDataReader.Tests.BattlefieldVietnam;

public class GameDataReadersTests
{
    private static IBfVietnamDataReader BfVietnamDataReader => new BfVietnamDataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = BfVietnamDataReader.ReadActivePlayer();

        Console.WriteLine($"Player Name: {player.OnlineName}");
    }

    [Test]
    public void GameDataReaders_BfVietnam_IsSingleton()
    {
        var bfVietnamDataReader1 = GameDataReaders.BfVietnam;
        var bfVietnamDataReader2 = GameDataReaders.BfVietnam;

        bfVietnamDataReader1.GetHashCode().Should()
            .Be(bfVietnamDataReader2.GetHashCode());
    }

    [Test]
    public void GameDataReaders_GetAccessor_IsNotSingleton()
    {
        var bfVietnamDataReader1 = BfVietnamDataReader;
        var bfVietnamDataReader2 = BfVietnamDataReader;

        bfVietnamDataReader1.GetHashCode().Should()
            .NotBe(bfVietnamDataReader2.GetHashCode());
    }
}