using System;
using System.IO;
using FluentAssertions;
using GameDataReader.Battlefield1942.Reader;
using GameDataReader.Common.Refractor.V1.Files;
using NUnit.Framework;

namespace GameDataReader.Tests.Battlefield1942;

public class GameDataReadersTests
{
    private static IBf1942DataReader Bf1942DataReader => new Bf1942DataReader();

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_Bf1942_ReadActivePlayer_DoesNotThrowLocally()
    {
        var player = Bf1942DataReader.ReadActivePlayer();

        Console.WriteLine($"[Bf1942_ReadActivePlayer_DoesNotThrowLocally] Player Name: {player.OnlineName}");
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

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_Bf1942_IsTrueProfileFileExists()
    {
        var GameName = "Battlefield 1942";
        var ModName = "bf1942";

        var globalRefractorV1ConfigFile = new GlobalRefractorV1ConfigFile(GameName, ModName);
        var filePath = globalRefractorV1ConfigFile.GetFilePath();

        Console.WriteLine($"[Bf1942_IsTrueProfileFileExists] File Path: {filePath}");

        Assert.IsTrue(File.Exists(filePath));
    }

    [Explicit("Only run this test on a real Windows machine, for end-to-end testing.")]
    [Test]
    public void GameDataReaders_Bf1942_IsTrueGeneralOptionsFileExists()
    {
        var GameName = "Battlefield 1942";
        var ModName = "bf1942";

        var globalRefractorV1ConfigFile = new GlobalRefractorV1ConfigFile(GameName, ModName);
        var activeProfileName = globalRefractorV1ConfigFile.GetCurrentlyActiveProfileName();

        var profileRefractorV1ConfigFile = new ProfileRefractorV1ConfigFile(GameName, ModName, activeProfileName);
        var filePath = profileRefractorV1ConfigFile.GetFilePath();

        Console.WriteLine($"[Bf1942_IsTrueGeneralOptionsFileExists] File Path: {filePath}");

        Assert.IsTrue(File.Exists(filePath));
    }
}