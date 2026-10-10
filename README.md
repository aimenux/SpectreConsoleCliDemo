[![.NET](https://github.com/aimenux/SpectreConsoleCliDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/SpectreConsoleCliDemo/actions/workflows/ci.yml)

# SpectreConsoleCliDemo
```
Exploring ways of using Spectre.Console.Cli to build CLI tools
```

In this repo, i m exploring various ways in order to build a simple cli tool based on [Spectre.Console.Cli](https://spectreconsole.net/cli).
>
> :one: [Example01](src/Example01) : commands metadata (name, description, etc.) are defined outside commands folder.
>
> :two: [Example02](src/Example02) : commands metadata (name, description, etc.) are defined inside commands folder.
>

To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `dotnet run --project .\src\Example01\Example01.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\Example02\Example02.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\Example01\Example01.csproj path list [path] -e [extension]`
> - `dotnet run --project .\src\Example02\Example02.csproj path list [path] -e [extension]`
>

**`Tools`** : net 10.0, spectre.console.cli
