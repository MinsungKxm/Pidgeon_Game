# Pidgeon Crossing

Pidgeon Crossing is a low-poly adventure and exploration game in which you play as a pigeon gentleman roaming through an urban city. Explore for as long as possible, avoid the oncoming vehicles, and make your single life count as the city repeatedly changes between day and night.

## Play or Download

- [Download Pidgeon Crossing for Windows on itch.io](https://minsungkim.itch.io/pidgeon-crossing)
- [Play the game in your browser on Unity Play](YOUR_UNITY_PLAY_LINK_HERE)

Replace the Unity Play placeholder above with the public game link after publishing the WebGL version.

## Table of Contents

1. [About the Game](#about-the-game)
2. [Features](#features)
3. [Controls](#controls)
4. [How to Play](#how-to-play)
5. [Installation](#installation)
6. [Playing the Web Version](#playing-the-web-version)
7. [Development](#development)
8. [Building the Project](#building-the-project)
9. [Project Structure](#project-structure)
10. [Known Limitations](#known-limitations)
11. [Credits](#credits)
12. [License](#license)

## About the Game

Pidgeon Crossing is a small 3D game developed entirely with Unity. It is the developer's first Unity game and was created as a hands-on introduction to building, completing, and publishing a playable project.

The player takes control of a pigeon gentleman and is free to travel around a low-poly urban city. There is no complicated mission or fixed route: the main objective is to explore, survive, and remain alive for as long as possible.

Vehicles continuously travel through the city and will immediately end the run if they hit the pigeon. The player has only one life, so safely crossing roads and paying attention to traffic are essential. Every 30 seconds, the environment switches between day and night, changing the appearance and atmosphere of the city while the run continues.

## Features

- Play as a pigeon gentleman in a low-poly urban environment
- Open-ended adventure and exploration gameplay
- Survival-based objective with only one life per run
- Moving vehicles that can instantly end the run
- Day and night states that alternate every 30 seconds
- Camera that follows the pigeon through the city
- Dedicated nighttime lighting and atmosphere
- Downloadable Windows edition available through itch.io
- Browser-playable WebGL edition available through Unity Play
- Built entirely in Unity with C# scripts and Unity components

## Controls

Confirm these bindings against the final game build and update them if necessary.

| Action | Control |
| --- | --- |
| Move | `W`, `A`, `S`, `D` or arrow keys |
| Look or turn | Mouse |
| Jump or fly | `Space` |
| Pause or exit a menu | `Esc` |

## How to Play

1. Launch the Windows download or open the Unity Play version.
2. Guide the pigeon around the low-poly city and explore as much of the environment as possible.
3. Watch the roads carefully and avoid every oncoming vehicle.
4. Survive as the environment alternates between day and night every 30 seconds.
5. Continue exploring for as long as possible. A single collision with a vehicle ends the run because the pigeon has only one life.

There is no required route through the city. The challenge comes from balancing exploration with the risk of crossing streets and moving near traffic.

## Installation

### Windows

1. Open the itch.io page using the link near the top of this README.
2. Download the Windows version of the game.
3. Extract the downloaded ZIP file to a folder on your computer.
4. Keep the executable and its accompanying data folder together.
5. Run the `.exe` file to start the game.

Windows may display a security warning for an unsigned application downloaded from the internet. Confirm that the file came from the official itch.io page before choosing to run it.

Do not move or distribute only the `.exe` file. A typical Unity Windows build also includes a matching `_Data` folder and supporting files required for the game to run.

### macOS and Linux

There are currently no downloadable macOS or Linux editions. The itch.io download is built for Windows only. Players on other operating systems can use the browser version on Unity Play if their browser and hardware support WebGL.

## Playing the Web Version

The WebGL edition can be played without installing the game:

1. Open the Unity Play link near the top of this README.
2. Allow the game to finish loading.
3. Click inside the game window so it can receive keyboard and mouse input.
4. Use fullscreen mode if the embedded window is too small.

Performance and loading time may vary depending on the browser and computer. A current desktop version of Chrome, Edge, or Firefox is recommended.

## Development

### Requirements

To open and modify the project, install:

- Unity Hub
- The Unity Editor version used by the project
- Microsoft Visual Studio, Visual Studio Code, or another C# editor
- Windows Build Support for Windows builds
- WebGL Build Support for browser builds
- macOS Build Support if creating a macOS build on supported hardware

The exact Unity Editor version can be found in:

```text
ProjectSettings/ProjectVersion.txt
```

### Opening the Project

1. Clone or download the repository.
2. Open Unity Hub.
3. Select **Add** or **Add project from disk**.
4. Choose the root folder of the project.
5. Open it using the Unity version listed in `ProjectSettings/ProjectVersion.txt`.
6. Allow Unity to import the assets and recreate generated folders.
7. Open the main scene from the `Assets` folder and press the Play button.

Generated folders such as `Library`, `Temp`, `Logs`, and `obj` should not be committed to Git. Unity recreates them when the project is opened.

### Technologies Used

- Unity
- C#
- Unity physics and collision components
- Unity lighting system
- WebGL for browser publishing
- Git and GitHub for version control

## Building the Project

### Windows Build

1. Open the project in Unity.
2. Open **File > Build Profiles**.
3. Select the Windows platform.
4. If necessary, choose **Switch Platform**.
5. Confirm that the main gameplay scene is included in the scene list.
6. Select **Build**.
7. Choose an empty output folder.
8. Test the generated executable before uploading the complete build as a ZIP file to itch.io.

### WebGL Build

1. Install WebGL Build Support through Unity Hub if it is not already installed.
2. Open **File > Build Profiles** in Unity.
3. Select Web and choose **Switch Platform** if required.
4. Confirm that the correct scene is included.
5. Select **Build** and choose an empty output folder.
6. Upload the WebGL build to Unity Play.
7. Test the published version in a browser and confirm that the controls, lighting, audio, and interface work correctly.

## Project Structure

A standard version of the repository is organized as follows:

```text
Pidgeon-Crossing/
├── Assets/                 Game scenes, scripts, models, materials, and audio
├── Packages/               Unity package configuration
├── ProjectSettings/        Project and editor settings
├── .gitignore              Files and generated folders excluded from Git
└── README.md               Project documentation
```

Only the Unity project source should be committed to the main source repository. Published Windows and WebGL builds can be distributed through itch.io and Unity Play instead of being committed alongside the source.

## Known Limitations

- The browser version may load or run more slowly than the desktop build.
- Visual quality and lighting can vary between the Windows and WebGL renderers.
- The downloadable edition currently supports Windows only.
- Controls are primarily designed for a keyboard and mouse unless controller support is added.
- The player has only one life; there is no health system protecting the pigeon from vehicle collisions.

## Credits

### Development

- Developed by Minsung Kim
- itch.io profile: [MinsungKim](https://minsungkim.itch.io/)

### Assets

List any third-party models, textures, sound effects, music, fonts, tutorials, or Unity Asset Store packages used in the project. Include the creator, source link, and license where applicable.

Example:

```text
Asset name — Creator
Source: https://example.com
License: License name
```

## License

No license has been specified for this project yet. Unless a license file is added, the source code and original assets remain under the copyright of their respective owner and may not automatically be reused or redistributed.

Third-party assets remain subject to their original licenses.
