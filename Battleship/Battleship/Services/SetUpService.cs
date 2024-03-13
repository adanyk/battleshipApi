using Battleship.Models;

namespace Battleship.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly Random _random = new();
        private const int _boardSize = 10;

        public List<List<Ship>> GenerateGameSetup()
        {
            var gameSetup = new List<List<Ship>>
            {
                GeneratePlayerSetup(),
                GeneratePlayerSetup()
            };

            return gameSetup;
        }

        private List<Ship> GeneratePlayerSetup()
        {
            var playerSetup = new List<Ship>();
            var shipSizes = new[] { 5, 4, 3, 3, 2 };
            var board = new bool[_boardSize, _boardSize];

            foreach (var size in shipSizes)
            {
                PlaceShipOnBoard(size, board, playerSetup);
            }

            return playerSetup;
        }

        private void PlaceShipOnBoard(int shipSize, bool[,] board, List<Ship> playerSetup)
        {
            var placed = false;
            while (placed == false)
            {
                var orientation = GetRandomOrientation();
                var coordinates = GetRandomCoordinates(shipSize, orientation);
                var newShip = new Ship { Coordinates = coordinates, Size = shipSize, Orientation = orientation };

                if (IsSpaceAvailable(newShip, board))
                {
                    RecordShipPlacement(newShip, board, playerSetup);
                    placed = true;
                }
            }
        }

        private Orientation GetRandomOrientation()
        {
            return _random.Next(2) == 0 ? Orientation.Horizontal : Orientation.Vertical;
        }

        private (int X, int Y) GetRandomCoordinates(int shipSize, Orientation orientation)
        {
            return orientation == Orientation.Horizontal
                ? (_random.Next(_boardSize), _random.Next(_boardSize + 1 - shipSize))
                : (_random.Next(_boardSize + 1 - shipSize), _random.Next(_boardSize));
        }

        private static bool IsSpaceAvailable(Ship ship, bool[,] board)
        {
            for (int offset = 0; offset < ship.Size; offset++)
            {
                var (X, Y) = CalculateOffsetCoordinates(ship.Coordinates, ship.Orientation, offset);
                if (board[X, Y]) return false;
            }
            return true;
        }

        private static (int X, int Y) CalculateOffsetCoordinates((int X, int Y) coordinates, Orientation orientation, int offset)
        {
            return orientation == Orientation.Vertical
                ? (coordinates.X + offset, coordinates.Y)
                : (coordinates.X, coordinates.Y + offset);
        }

        private static void RecordShipPlacement(Ship ship, bool[,] board, List<Ship> playerSetup)
        {
            for (int offset = 0; offset < ship.Size; offset++)
            {
                var (placeX, placeY) = CalculateOffsetCoordinates(ship.Coordinates, ship.Orientation, offset);
                board[placeX, placeY] = true;
            }

            playerSetup.Add(ship);
        }
    }
}
