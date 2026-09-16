# SamSWAT's FOV Mod — SPT 3.9.8 Port

A community-maintained port of **SamSWAT's FOV Mod**, adapted to work with **SPT (Single Player Tushonka) 3.9.8**.

This repository contains the changes required to compile and run the mod with **SPT 3.9.8**, along with additional viewmodel customization functionality and compatibility with **Fontaine's FOVFix**.

> **Important:** This version of the mod is intended specifically for **SPT 3.9.8**. Compatibility with other SPT versions is not guaranteed.

### Extended FOV Range

Expands the game's default Field of View slider range and allows custom minimum and maximum FOV values to be configured through BepInEx.

The default configuration provided by this port allows FOV values from **20 to 150**.

### Viewmodel Customization

Provides additional control over the position of the first-person camera and weapon viewmodel.

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

## Configuration

The mod creates a BepInEx configuration file on first launch.

The available settings include:

| Setting | Description | Default |
|---|---|---:|
| **Min FOV Value** | Minimum value available in the game's FOV slider. | 20 |
| **Max FOV Value** | Maximum value available in the game's FOV slider. | 150 |
| **Horizontal Offset** | Adjusts the horizontal position of the camera and weapon viewmodel. | 0.04 |
| **Vertical Offset** | Adjusts the vertical position of the camera and weapon viewmodel. | 0.04 |
| **Depth Offset** | Adjusts the forward/backward position of the camera and weapon viewmodel. | 0.05 |

The configuration file is located at:

```text
BepInEx/config/com.samswat.fov.cfg
```

### Changing the FOV

After installing the mod:

1. Launch SPT.
2. Press **F12** to open the BepInEx menu and set your desired minimum/maximum FOV range.
3. Open the main menu **Settings**.
4. Navigate to the **Game** tab.
5. Adjust the **FOV** slider to your preferred value within your new custom range.

### Customizing the Viewmodel

The **Horizontal Offset**, **Vertical Offset**, and **Depth Offset** settings can be used to adjust the position of the first-person camera and weapon viewmodel.

For example:

- Increase **Horizontal Offset** to move the viewmodel to the right.
- Decrease it to move the viewmodel to the left.
- Increase **Vertical Offset** to move the viewmodel upward.
- Decrease it to move the viewmodel downward.
- Increase **Depth Offset** to move the viewmodel closer to the player.
- Decrease it to move the viewmodel farther away.

The offsets are applied continuously while the camera is updated, allowing the configured position to remain active during gameplay.

## Compatibility

This release is specifically built and tested for **SPT 3.9.8**.

SPT versions can use different game assemblies and internal structures. This mod modifies game behavior through patches and reflection, so changes between SPT versions may require additional porting work.

Compatibility with other SPT versions has **not** been tested and should not be assumed.

## Known Limitations

- Extreme FOV values may produce visual glitches, clipping, or unusual weapon and hand positioning depending on your resolution and aspect ratio.
- Compatibility with other mods that alter the camera, FOV, weapon animations, or related game settings is not guaranteed unless explicitly stated.

## Credits & Acknowledgments

- **Original Author:** [SamSWAT](https://github.com/SamSWAT911) — creator of the original SamSWAT FOV mod.
- **SPT Team:** For creating and maintaining the Single Player Tushonka framework.
- **FOVFix Author:** [Fontaine](https://github.com/space-commits) — creator of FOVFix and provider of the functionality this port is designed to remain compatible with.
- **Port / Maintenance:** **Z1vvs** — adaptation, additional viewmodel customization functionality, FOVFix compatibility, and maintenance of the SPT 3.9.8 port.

## Disclaimer

This is a community-maintained port of an existing mod. It is not affiliated with or endorsed by SamSWAT, Fontaine, Battlestate Games, or the SPT development team.

The original author's work and credit remain with the original author. This repository exists to preserve and maintain the mod for users of **SPT 3.9.8**.