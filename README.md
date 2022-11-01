[![.NET](https://github.com/aimenux/SpectreCliDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/SpectreCliDemo/actions/workflows/ci.yml)

# SpectreCliDemo
```
Exploring ways of using Spectre.Console to build CLI tools
```

In this repo, i m exploring various ways in order to build a simple cli tool based on [Spectre.Console](https://spectreconsole.net/cli/).
>
> :one: basic way : commands metadata (name, description, etc.) are described outside commands folder.
>
> :two: custom way : commands metadata (name, description, etc.) are described inside commands folder.
>

To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `.\BasicWay.exe math add [number1] [number2]`
> - `.\CustomWay.exe math add [number1] [number2]`
> - `.\BasicWay.exe path list [path] -e [extension]`
> - `.\CustomWay.exe path list [path] -e [extension]`
>

**`Tools`** : vs22, net 6.0, spectre.console.cli
