using GameDataReader.Common.Parsing;

namespace GameDataReader.BattlefieldBadCompany2.Parsing;

/// <summary>
/// Represents a setting inside of a GameSettings.ini configuration file.
/// </summary>
internal class BfBc2GameSettingsBinSetting : Setting
{
    private readonly string _value;

    /// <param name="value">i.e. mister249</param>
    public BfBc2GameSettingsBinSetting(string value)
    {
        _value = value;
    }

    public override string GetValue()
    {
        return _value;
    }
}