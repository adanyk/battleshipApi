# Battleship Api

This project is the backend API for the Battleship game simulator, built using .NET 8. It handles the game logic, including the random placement of ships and the simulation of gameplay between two players.

## Getting Started

Ensure you have [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed to run this project, then follow the steps:

1. Clone the repository:
```
git clone https://github.com/adanyk/battleshipApi/
```
2. Navigate to the project directory:
```
cd battleshipApi
```
3. Run the API locally:
```
dotnet run --project Battleship/Battleship/Battleship.csproj --urls="https://localhost:7120"
```
4. Get the frontend [here](https://github.com/adanyk/battleshipWeb)

## Features
* Generates a game setup with randomly placed ships for two players.
* Simulates the sequence of shots based on the game logic.
* Provides an endpoint to retrieve the game setup and the simulated gameplay.

## Development Notes
* Utilizes dependency injection for service management.
* Includes unit tests for controllers and services.
