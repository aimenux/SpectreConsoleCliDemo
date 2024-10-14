[![.NET](https://github.com/aimenux/SpectreCliDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/SpectreCliDemo/actions/workflows/ci.yml)

# SpectreConsoleCliDemo
```
Exploring ways of using Spectre.Console to build CLI tools
```

In this repo, i m exploring various ways in order to build a simple cli tool based on [Spectre.Console](https://spectreconsole.net/cli/).
>
> :one: basic way : commands metadata (name, description, etc.) are defined outside commands folder.
>
> :two: custom way : commands metadata (name, description, etc.) are defined inside commands folder.
>

To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `dotnet run --project .\src\BasicWay\BasicWay.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\CustomWay\CustomWay.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\BasicWay\BasicWay.csproj path list [path] -e [extension]`
> - `dotnet run --project .\src\CustomWay\CustomWay.csproj path list [path] -e [extension]`
>

**`Tools`** : net 8.0, spectre.console.cli
