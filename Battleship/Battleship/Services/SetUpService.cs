using Battleship.Models;

namespace Battleship.Services
{
    public class SetUpService : ISetUpService
    {
        public List<List<ShipPosition>> GenerateGameSetup()
        {
            List<List<ShipPosition>> gameSetup = [];
            gameSetup.Add(GeneratePlayerSetup());
            gameSetup.Add(GeneratePlayerSetup());

            return gameSetup;
        }

        private List<ShipPosition> GeneratePlayerSetup()
        {
            List<ShipPosition> playerSetup = [];
            int[] shipSizes = [5, 4, 3, 3, 2];
            bool[,] board = new bool[10, 10];
            Random random = new();

            foreach (var size in shipSizes)
            {
                bool placed = false;
                while (!placed)
                {
                    var orientation = random.Next(2) == 0 ? Orientation.Horizontal : Orientation.Vertical;
                    int startX, startY;

                    if (orientation == Orientation.Horizontal)
                    {
                        startX = random.Next(10);
                        startY = random.Next(11 - size);
                    }
                    else
                    {
                        startX = random.Next(11 - size);
                        startY = random.Next(10);
                    }

                    if (CanPlaceShip(startX, startY, size, orientation, board))
                    {
                        PlaceShip(startX, startY, size, orientation, board);
                        playerSetup.Add(new ShipPosition { Coordinates = (startX, startY), Size = size, Orientation = orientation });
                        placed = true;
                    }
                }
            }

            return playerSetup;
        }

        private static bool CanPlaceShip(int x, int y, int size, Orientation orientation, bool[,] board)
        {
            for (int i = 0; i < size; i++)
            {
                int checkX = x + (orientation == Orientation.Vertical ? i : 0);
                int checkY = y + (orientation == Orientation.Horizontal ? i : 0);

                if (board[checkX, checkY]) return false; // This position is already occupied
            }

            return true; // All positions for the ship are free
        }

        private static void PlaceShip(int x, int y, int size, Orientation orientation, bool[,] board)
        {
            for (int i = 0; i < size; i++)
            {
                int placeX = x + (orientation == Orientation.Vertical ? i : 0);
                int placeY = y + (orientation == Orientation.Horizontal ? i : 0);

                board[placeX, placeY] = true; // Mark the position as occupied
            }
        }
    }
}
