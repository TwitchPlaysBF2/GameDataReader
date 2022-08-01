namespace GameDataReader.BattlefieldBadCompany2.Parsing;

/// <summary>
/// Represents a setting inside of a GameSettings.ini configuration file.
/// </summary>
internal class Setting : Common.Parsing.Setting
{
    private readonly string _value;

    /// <param name="value">i.e. mister249</param>
    public Setting(string value)
    {
        _value = value;
    }

    public override string ParseValue()
    {
        return _value;
    }
}