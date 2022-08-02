[![Continuous Deployment](https://img.shields.io/github/workflow/status/TwitchPlaysBF2/GameDataReader/Continuous%20Deployment?label=Continuous%20Deployment&logo=github&style=flat-square)](https://github.com/TwitchPlaysBF2/GameDataReader/actions/workflows/Continuous%20Deployment.yaml)

# GameDataReader
An open-source NuGet library providing simple access to game settings.

Reading data from games like Battlefield 2 - i.e. to access player data from BF2 specific .con configuration files.

Open to integration of more games & data.

# Usage

- Add the `GameDataReader` NuGet package to your project: `Install-Package GameDataReader`
- Add import statement: `using GameDataReader;`
- For (optional) dependency injection, register your preferred DataReader to your `IServiceCollection` by configuring i.e. `services.AddBf2DataReader();` and you're ready to inject i.e. `IBf2DataReader` instances.
- For (straight forward) static access to GameData, simply invoke a supported method like: `GameDataReaders.Bf2.ReadActivePlayer()`

# Currently supported games

## Battlefield 1942

- `GameDataReaders.Bf1942.ReadActivePlayer()`
    - `Bf1942Player.OnlineName` - from `{localAppData}\VirtualStore\Program Files (x86)\EA GAMES\Battlefield 1942\Mods\bf1942\Settings\Profiles\{profileName}\GeneralOptions.con`

## Battlefield Vietnam

- `GameDataReaders.BfVietnam.ReadActivePlayer()`
  - `BfVietnamPlayer.OnlineName` - from `{localAppData}\VirtualStore\Program Files (x86)\EA GAMES\Battlefield Vietnam\Mods\BfVietnam\settings\Profiles\{profileName}\GeneralOptions.con`

## Battlefield 2

- `GameDataReaders.Bf2.ReadActivePlayer()`
    - `Bf2Player.OnlineName` - from `{userDocuments}\Battlefield 2\Profiles\{profileNumber}\Profile.con`
    - `Bf2Player.ClanTag` - from `{userDocuments}\Battlefield 2\Profiles\Global.con`

## Battlefield 2142

- `GameDataReaders.Bf2142.ReadActivePlayer()`
  - `Bf2142Player.OnlineName` - from `{userDocuments}\Battlefield 2142\Profiles\{profileNumber}\Profile.con`
  - `Bf2142Player.ClanTag` - from `{userDocuments}\Battlefield 2142\Profiles\Global.con`
