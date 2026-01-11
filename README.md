# HelloWorldTVApp

A minimal demonstration TV application for **Schedule I** using the S1API framework. This project showcases how to create a simple TV app that integrates with the game's TV system.

## What It Does

The Hello World TV app displays:
- A centered "Hello World!" message on a dark background
- An animated color-cycling effect (white, cyan, yellow, green, magenta)
- A custom programmatically-generated icon

## Technology Stack

| Technology | Purpose |
|---|---|
| .NET (C# 11.0) | Base framework |
| Unity Engine | Game engine integration |
| MelonLoader 0.7.0 | Mod loading framework |
| S1API | TV app system and UI utilities |

## Project Structure

```
HelloWorldTVApp/
├── HelloWorldTVApp.cs    # Main TV app implementation
├── Core.cs               # MelonLoader entry point
├── HelloWorldTVApp.csproj
├── local.build.props     # Build configuration (create from template)
└── bin/                  # Compiled output
```

## Prerequisites

- .NET SDK 6.0+
- Schedule I game installation
- MelonLoader installed in the game
- S1API project (sibling directory)

## Setup

1. Copy `local.build.props` and configure the paths:

```xml
<PropertyGroup>
    <GameFolder>C:\path\to\Schedule I</GameFolder>
    <MelonLoaderFolder>$(GameFolder)\MelonLoader\net6</MelonLoaderFolder>
    <UnityFolder>$(MelonLoaderFolder)\Managed</UnityFolder>
    <S1APIBuildFolder>..\S1API\bin\$(Configuration)\$(S1APITargetFramework)</S1APIBuildFolder>
</PropertyGroup>
```

2. Build the S1API project first (if not already built)

## Building

```bash
# Build for Mono runtime
dotnet build -c Mono

# Build for IL2CPP runtime
dotnet build -c Il2cpp

# Build version-agnostic
dotnet build -c CrossCompat
```

The compiled DLL is automatically copied to the game's Mods folder if `GameFolder` is configured.

## Installation

1. Build the project with your preferred configuration
2. Copy the output DLL from `bin/{Configuration}/{Framework}/` to your game's `Mods` folder
3. Launch Schedule I with MelonLoader
4. Find the "Hello World" app on in-game TVs

## Code Overview

### Core.cs
Entry point for MelonLoader. Registers the mod and logs initialization.

### HelloWorldTVApp.cs
Main TV app class extending `TVApp` from S1API:
- `AppName` / `AppTitle`: App identification
- `Icon`: Dynamically generated sprite
- `OnCreatedUI()`: Creates background and text elements
- `OnOpened()`: Initializes state when app opens
- `OnUpdate()`: Handles color cycling animation

## License

MIT
