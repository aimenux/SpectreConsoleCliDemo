[![.NET](https://github.com/aimenux/SpectreConsoleCliDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/SpectreConsoleCliDemo/actions/workflows/ci.yml)

# SpectreConsoleCliDemo
```
Exploring ways of using Spectre.Console.Cli to build CLI tools
```

In this repo, i m exploring various ways to build a simple cli tool based on [Spectre.Console.Cli](https://spectreconsole.net/cli).
All examples expose the same commands (`math add|sub` and `path list|count`), only the way commands are organized and registered differs.

> 1️⃣ [Example01](src/Example01) : one configurator for all commands (`Program.cs`).
>
> 2️⃣ [Example02](src/Example02) : one configurator per command group (`MathConfigurator.cs`, `PathConfigurator.cs`).
>
> 3️⃣ [Example03](src/Example03) : one configurator per command (`AddConfigurator.cs`, `SubConfigurator.cs`, etc.).

### Pros / Cons

**Example01** : metadata defined outside commands
- ➕ simplest approach, no extra abstraction, easy to follow for small tools
- ➕ whole command tree (names, aliases, examples) visible at a glance
- ➖ commands and their metadata live apart, so they can drift out of sync
- ➖ central registration grows and becomes a merge-conflict hotspot as commands increase

**Example02** : metadata defined per command group
- ➕ metadata sits next to the commands it describes
- ➕ groups are self-contained and discovered automatically, `Program.cs` stays untouched
- ➕ few files, a group's commands are registered together
- ➖ adding a command still means editing the group configurator
- ➖ commands of a group share one settings class, so settings can't diverge cleanly

**Example03** : one folder per command
- ➕ fully self-contained commands: add or remove one by adding or deleting a folder, no other file to edit
- ➕ each command owns its settings, so they can evolve independently
- ➕ scales best for large tools and teams (small, isolated diffs)
- ➖ more files and folders, some boilerplate (configurator and settings per command)
- ➖ the command tree is spread out; a configurator must declare which `Branch` it belongs to, and `Rank` controls ordering

**When to use what** : Example01 for small tools or prototypes, Example02 for medium tools with a few command groups, Example03 for large tools with many commands.

### Run

To run code in debug or release mode, type the following commands in your favorite terminal :
> - `dotnet run --project .\src\Example01\Example01.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\Example02\Example02.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\Example03\Example03.csproj math add [number1] [number2]`
> - `dotnet run --project .\src\Example01\Example01.csproj path list [path] -e [extension]`
> - `dotnet run --project .\src\Example02\Example02.csproj path list [path] -e [extension]`
> - `dotnet run --project .\src\Example03\Example03.csproj path list [path] -e [extension]`

**`Tools`** : net 10.0, spectre.console.cli
