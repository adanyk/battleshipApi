using Battleship.Models;

namespace Battleship.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly Random _random = new();
        private const int BoardSize = 10;

        public IEnumerable<IEnumerable<ShipPosition>> GenerateGameSetup()
        {
            var gameSetup = new List<List<ShipPosition>>
            {
                GeneratePlayerSetup(),
                GeneratePlayerSetup()
            };

            return gameSetup;
        }

        private List<ShipPosition> GeneratePlayerSetup()
        {
            var playerSetup = new List<ShipPosition>();
            var shipSizes = new[] { 5, 4, 3, 3, 2 };
            var board = new bool[BoardSize, BoardSize];

            foreach (var size in shipSizes)
            {
                PlaceShipOnBoard(size, board, playerSetup);
            }

            return playerSetup;
        }

        private void PlaceShipOnBoard(int shipSize, bool[,] board, List<ShipPosition> playerSetup)
        {
            var placed = false;
            while (!placed)
            {
                var orientation = GetRandomOrientation();
                var (startX, startY) = GetRandomCoordinates(shipSize, orientation);

                if (IsSpaceAvailable(startX, startY, shipSize, orientation, board))
                {
                    RecordShipPlacement(startX, startY, shipSize, orientation, board, playerSetup);
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
            if (orientation == Orientation.Horizontal)
            {
                return (_random.Next(BoardSize), _random.Next(BoardSize + 1 - shipSize));
            }
            else
            {
                return (_random.Next(BoardSize + 1 - shipSize), _random.Next(BoardSize));
            }
        }

        private static bool IsSpaceAvailable(int x, int y, int size, Orientation orientation, bool[,] board)
        {
            for (int offset = 0; offset < size; offset++)
            {
                var (checkX, checkY) = CalculateOffsetCoordinates(x, y, orientation, offset);
                if (board[checkX, checkY]) return false;
            }
            return true;
        }

        private static (int X, int Y) CalculateOffsetCoordinates(int x, int y, Orientation orientation, int offset)
        {
            if (orientation == Orientation.Vertical)
            {
                return (x + offset, y);
            }
            else
            {
                return (x, y + offset);
            }
        }

        private static void RecordShipPlacement(int x, int y, int size, Orientation orientation, bool[,] board, List<ShipPosition> playerSetup)
        {
            for (int offset = 0; offset < size; offset++)
            {
                var (placeX, placeY) = CalculateOffsetCoordinates(x, y, orientation, offset);
                board[placeX, placeY] = true;
            }

            playerSetup.Add(new ShipPosition { Coordinates = (x, y), Size = size, Orientation = orientation });
        }
    }
}
