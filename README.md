# SamSWAT's FOV Mod — SPT 3.9.8 Port

A community-maintained port of **SamSWAT's FOV Mod**, adapted to work with **SPT (Single Player Tushonka) 3.9.8**.

This repository contains the changes required to compile and run the mod with **SPT 3.9.8**, along with additional viewmodel customization functionality and compatibility with **Fontaine's FOVFix**.

> **Important:** This version of the mod is intended specifically for **SPT 3.9.8**. Compatibility with other SPT versions is not guaranteed.

## Features

### Extended FOV Range

Expands the game's default Field of View slider range and allows custom minimum and maximum FOV values to be configured through BepInEx.

By default, this port uses a FOV range of **50 to 75**. Both limits can be configured from **1 to 150**.

### Viewmodel Customization

Provides additional control over the position of the first-person camera and weapon viewmodel through BepInEx configuration.

The following offsets can be configured independently:

- **Horizontal Offset** — Moves the camera/viewmodel horizontally.
- **Vertical Offset** — Moves the camera/viewmodel vertically.
- **Depth Offset** — Moves the camera/viewmodel forward or backward relative to the player.

This allows the weapon and hands to be repositioned to better suit higher or lower FOV values.

### Fontaine's FOVFix Compatibility

The mod includes compatibility handling for **Fontaine's FOVFix**.

When FOVFix is installed, the mod reapplies its configured viewmodel offsets after FOVFix updates the camera, ensuring the configured offsets remain active.

Fontaine's FOVFix is optional. When installed, compatibility handling is automatically applied. The mod works normally without it.

## Installation

### 1. Verify Your SPT Version

Make sure you are running **SPT 3.9.8** before installing the mod.

### 2. Download the Mod

Download the latest release ZIP from the [Releases](../../releases) section of this repository.

### 3. Extract the Archive

Extract the contents of the downloaded archive directly into your main SPT installation directory.

After installation, the plugin should be located at:

```text
<Your SPT Folder>/
└── BepInEx/
    └── plugins/
        └── SamSWAT-FOV/
            └── SamSWAT.FOV.dll
```

### 4. Launch SPT

Start SPT normally.

The mod should be loaded automatically by BepInEx. You can verify that `SamSWAT.FOV.dll` was loaded successfully through the BepInEx console or log files.

## Compatibility

This release is specifically built and tested for **SPT 3.9.8**.

SPT versions can use different game assemblies and internal structures. This mod modifies game behavior through patches and reflection, so changes between SPT versions may require additional porting work.

Compatibility with other SPT versions has **not** been tested and should not be assumed.

Compatibility with other mods that alter the camera, FOV, weapon animations, or related game settings is **not** guaranteed unless explicitly stated.

## Credits & Acknowledgments

- **Original Author:** [SamSWAT](https://github.com/SamSWAT911) — creator of the original SamSWAT FOV mod.
- **SPT Team:** - creation and maintenance of the Single Player Tushonka framework.
- **FOVFix Author:** [Fontaine](https://github.com/space-commits) — creator of FOVFix.
- **Port / Maintenance:** **Z1vvs** — adaptation, additional viewmodel customization functionality, FOVFix compatibility, and maintenance of the SPT 3.9.8 port.

## Disclaimer

This is a community-maintained port of an existing mod. It is not affiliated with or endorsed by SamSWAT, Fontaine, Battlestate Games, or the SPT development team.

The original author's work and credit remain with the original author. This repository exists to preserve and maintain the mod for users of **SPT 3.9.8**.