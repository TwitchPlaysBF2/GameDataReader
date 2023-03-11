using System;
using System.IO;
using FluentAssertions;
using GameDataReader.BattlefieldVietnam.Reader;
using GameDataReader.Common.Refractor.V1.Files;
using NUnit.Framework;

namespace GameDataReader.Tests.BattlefieldVietnam;

public class GameDataReadersTests
{
    private static IBfVietnamDataReader BfVietnamDataReader => new BfVietnamDataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_BfVietnam_ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = BfVietnamDataReader.ReadActivePlayer();

        Console.WriteLine($"[BfVietnam_ReadActivePlayer_DoesNotThrowLocally] Player Name: {player.OnlineName}");
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

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_BfVietnam_IsTrueProfileFileExists()
    {
        var GameName = "Battlefield Vietnam";
        var ModName = "BfVietnam";

        var globalRefractorV1ConfigFile = new GlobalRefractorV1ConfigFile(GameName, ModName);
        var filePath = globalRefractorV1ConfigFile.GetFilePath();

        Console.WriteLine($"[BfVietnam_IsTrueProfileFileExists] File Path: {filePath}");

        Assert.IsTrue(File.Exists(filePath));
    }

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_BfVietnam_IsTrueGeneralOptionsFileExists()
    {
        var GameName = "Battlefield Vietnam";
        var ModName = "BfVietnam";

        var globalRefractorV1ConfigFile = new GlobalRefractorV1ConfigFile(GameName, ModName);
        var activeProfileName = globalRefractorV1ConfigFile.GetCurrentlyActiveProfileName();

        var profileRefractorV1ConfigFile = new ProfileRefractorV1ConfigFile(GameName, ModName, activeProfileName);
        var filePath = profileRefractorV1ConfigFile.GetFilePath();

        Console.WriteLine($"[BfVietnam_IsTrueGeneralOptionsFileExists] File Path: {filePath}");

        Assert.IsTrue(File.Exists(filePath));
    }
}