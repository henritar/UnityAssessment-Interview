
# Matching Cards - Unity Game Project

Welcome to the **Matching Cards** Unity game project! This is a classic memory game where players flip cards to find matching pairs. The project utilizes the **Zenject** framework for Dependency Injection and **UniRx** for reactive programming and asynchronous event handling, providing a solid and efficient architecture. Follow the instructions below to set up and experience the project.

## Table of Contents

- [Project Description](#project-description)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Game Mechanics](#game-mechanics)
  - [Cards](#cards)
  - [Gameplay](#gameplay)
  - [Player Interaction](#player-interaction)
- [Assets](#assets)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Project Description

**Matching Cards** is a Unity3D game that follows the classic memory card game mechanics. The player flips cards to find matching pairs, with each pair removed from the board once matched. The goal is to match all pairs with the fewest possible flips.

## Architecture

The project follows the **[MVC](https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development)** pattern and uses two third-party libraries: **[Zenject](https://github.com/modesttree/Zenject)** for managing dependencies and **[UniRx](https://github.com/neuecc/UniRx)** for managing asynchronous events and data using the **Observables** design pattern.

Zenject enables a loosely coupled architecture by using [Installers](https://github.com/modesttree/Zenject#installers) and [Signals](https://github.com/modesttree/Zenject/blob/master/Documentation/Signals.md) to manage game components, ensuring high modularity and clear separation of concerns.

Other design patterns implemented with Zenject include:
- **[Factory](https://github.com/modesttree/Zenject/blob/master/Documentation/Factories.md)** for instantiating new Prefabs (such as cards and effects).
- **[Memory Pooling](https://github.com/modesttree/Zenject/blob/master/Documentation/MemoryPools.md)** for managing reusable objects, improving performance.
- **[Singleton](https://github.com/modesttree/Zenject#installers:~:text=AsSingle%20%2D%20Exactly%20the,a%20second%20instance.)** to ensure that key game components are shared and reused across different systems.

The **UniRx** library is used for efficient management of asynchronous data and events. It simplifies handling coroutines, reactive collections (such as the cards on the board), and observer-based patterns for game state changes, such as flipping cards and updating the game UI.

## Getting Started

### Prerequisites

- Unity3D (Version 2021.3.16f1 or newer)
- Zenject Framework (Version 9.2.0)
- UniRx Framework (Version 7.1.0)

### Installation

1. Clone this repository to your local machine.
2. Open the project using Unity3D.
3. Ensure that the Zenject and UniRx frameworks are properly integrated into the project.

## Game Mechanics

### Cards

- Each card has a front and back side.
- The cards are shuffled and placed face down on the board at the start of the game.

### Gameplay

- The player can flip two cards at a time.
- If the cards match, they are removed from the board.
- If they do not match, they are flipped back down.
- The game ends when all pairs are matched.

### Player Interaction

- Players can click on cards to flip them.
- The game tracks the number of flips and matches made in a row (Combo system).
- A scoring system has been implemented that rewards the most consecutive matches with bonus points.

## Assets

- **Sounds**: All sound effects used in the game were sourced from **[Freesound](https://freesound.org/)**.
- **Images**: The card images and other graphical elements were sourced from **[Freepik](https://www.freepik.com/)**.

## Dependencies

- Zenject Framework (Version 9.2.0)
- UniRx Framework (Version 7.1.0)

## Contributing

Contributions are welcome! Please follow the standard guidelines for submitting issues or pull requests.

## License

This project is licensed under the [MIT License](LICENSE).

---

Enjoy playing **Matching Cards**! If you have any questions or need assistance, feel free to reach out.

*Project created by Henrique Torres.* 
