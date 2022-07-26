using FluentAssertions;
using GameDataReader.Battlefield2.Parsing;
using NUnit.Framework;

namespace GameDataReader.Tests.Battlefield2.Parsing;

public class SettingTests
{
    [Test]
    public void ParseValue_WithValidLineAndValidKey_ReturnsValue()
    {
        const string configLine = "LocalProfile.setGamespyNick \"TwitchPlaysBF2\"";
        const string settingKey = "LocalProfile.setGamespyNick";
        var setting = new Setting(configLine, settingKey);

        var value = setting.ParseValue();

        value.Should().Be("TwitchPlaysBF2");
    }

    [Test]
    public void ParseValue_ShouldRemoveKeyFromConfigLine_ReturnsValueWithoutKey()
    {
        const string configLine = "LocalProfile.setGamespyNick \"TwitchPlaysBF2\"";
        const string settingKey = "LocalProfile.setGamespyNick";
        var setting = new Setting(configLine, settingKey);

        var value = setting.ParseValue();

        value.Should().NotContain(settingKey);
    }

    [Test]
    public void ParseValue_WithInvalidLineAndValidKey_Throws()
    {
        const string configLine = "some.other config line";
        const string settingKey = "LocalProfile.setGamespyNick";
        var setting = new Setting(configLine, settingKey);

        var act = () => setting.ParseValue();

        act.Should().Throw<GameDataReaderException>().Where(ex =>
            ex.Message.StartsWith(
                $"The setting {settingKey} could not be parsed correctly. Key not found in config line:"));
    }

    [Test]
    public void WithoutConfigLine_Throws()
    {
        const string configLine = " ";
        const string settingKey = "a.config.key";
        var act = () => new Setting(configLine, settingKey);

        act.Should().Throw<GameDataReaderException>().Where(ex =>
            ex.Message.StartsWith($"Failed to identify setting '{settingKey}'"));
    }

    [Test]
    public void WithoutSetting_Throws()
    {
        const string configLine = "a.config.key";
        const string settingKey = "";
        var act = () => new Setting(configLine, settingKey);

        act.Should().Throw<GameDataReaderException>().Where(ex =>
            ex.Message.StartsWith($"Failed to identify setting '{settingKey}'"));
    }
}