# GameDataReader
An open-source NuGet library providing simple access to game settings. 

Reading data from games like Battlefield 2 - i.e. to access player data from BF2 specific .con configuration files.

Open to integration of more games & data.

# Usage

- Add the `GameDataReader` NuGet package to your project: `Install-Package GameDataReader`
- Add import statement: `using GameDataReader;`
- For (optional) dependency injection, register your preferred DataReader to your `IServiceCollection` by configuring: `services.AddBf2DataReader();`
- For (straight forward) static access to GameData, simply invoke a supported method like: `GameDataReaders.Bf2.ReadActivePlayer()`

# Currently supported games

## Battlefield 2

- `GameDataReaders.Bf2.ReadActivePlayer()`
    - Bf2Player.OnlineName - from `{userDocuments}\Battlefield 2\Profiles\{profileNumber}\Profile.con`
    - Bf2Player.ClanTag - from `{userDocuments}\Battlefield 2\Profiles\Global.con`
