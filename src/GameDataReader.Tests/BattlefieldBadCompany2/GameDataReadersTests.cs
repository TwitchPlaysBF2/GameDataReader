using System;
using FluentAssertions;
using GameDataReader.BattlefieldBadCompany2.Reader;
using NUnit.Framework;

namespace GameDataReader.Tests.BattlefieldBadCompany2;

public class GameDataReadersTests
{
    private static IBfBc2DataReader BfBc2DataReader => new BfBc2DataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = BfBc2DataReader.ReadActivePlayer();

        Console.WriteLine($"Player Name: {player.OnlineName}");
        Console.WriteLine($"Prefix: {player.ClanTag}");
    }

    [Test]
    public void GameDataReaders_BfBc2_IsSingleton()
    {
        var bfBc2DataReader1 = GameDataReaders.BfBc2;
        var bfBc2DataReader2 = GameDataReaders.BfBc2;

        bfBc2DataReader1.GetHashCode().Should()
            .Be(bfBc2DataReader2.GetHashCode());
    }

    [Test]
    public void GameDataReaders_GetAccessor_IsNotSingleton()
    {
        var bfBc2DataReader1 = BfBc2DataReader;
        var bfBc2DataReader2 = BfBc2DataReader;

        bfBc2DataReader1.GetHashCode().Should()
            .NotBe(bfBc2DataReader2.GetHashCode());
    }
}