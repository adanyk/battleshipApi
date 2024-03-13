using Battleship.Models;

namespace Battleship.Services
{
    public class GameplayService : IGameplayService
    {
        private readonly Random _random = new();
        private const int _boardSize = 10;
        private const int _numberOfPlayers = 2;
        private const int _numberOfShips = 5;

        public List<Shot> GenerateShots(List<List<Ship>> ships)
        {
            var shots = new List<Shot>();
            var players = InitializePlayers(ships);
            var whoseTurn = 0;

            while (IsGameOver(players[whoseTurn]) == false)
            {
                shots.Add(ExecuteTurn(players, ref whoseTurn));
            }

            return shots;
        }

        private static Player[] InitializePlayers(List<List<Ship>> ships)
        {
            return Enumerable.Range(0, _numberOfPlayers).Select(i => new Player
            {
                MyShips = GetShips(ships[i]),
                TakenShots = new bool[_boardSize, _boardSize],
                NumberOfSunkShips = 0
            }).ToArray();
        }

        private static IEnumerable<IEnumerable<(int X, int Y)>> GetShips(List<Ship> ships)
        {
            return ships.Select(sp =>
                Enumerable.Range(0, sp.Size)
                          .Select(offset => CalculateOffsetCoordinates(sp, offset))
                          .ToList()
            ).ToList();
        }

        private static (int X, int Y) CalculateOffsetCoordinates(Ship ship, int offset)
        {
            return ship.Orientation == Orientation.Vertical
                ? (ship.Coordinates.X + offset, ship.Coordinates.Y)
                : (ship.Coordinates.X, ship.Coordinates.Y + offset);
        }

        private static bool IsGameOver(Player player)
        {
            return player.NumberOfSunkShips == _numberOfShips;
        }

        private Shot ExecuteTurn(Player[] players, ref int whoseTurn)
        {
            var currentPlayer = players[whoseTurn];
            var enemyPlayer = players[OpponentIndex(whoseTurn)];
            var shot = GenerateShot(currentPlayer, enemyPlayer.MyShips);

            if (shot.Result == ShotResult.Sunk)
            {
                currentPlayer.IncrementSunkShips();
            }

            whoseTurn = OpponentIndex(whoseTurn);
            return shot;
        }

        private static int OpponentIndex(int currentPlayerIndex)
        {
            return currentPlayerIndex == 0 ? 1 : 0;
        }

        private Shot GenerateShot(Player player, IEnumerable<IEnumerable<(int X, int Y)>> enemyShips)
        {
            var coordinates = GenerateRandomShotCoordinates(player);
            player.MarkShot(coordinates);
            var result = DetermineShotResult(enemyShips, coordinates, player.TakenShots);
            return new Shot { Coordinates = coordinates, Result = result };
        }

        private (int X, int Y) GenerateRandomShotCoordinates(Player player)
        {
            var isShotTaken = true;
            var coorX = 0;
            var coorY = 0;

            while (isShotTaken)
            {
                coorX = _random.Next(_boardSize);
                coorY = _random.Next(_boardSize);

                isShotTaken = player.TakenShots[coorX, coorY];
            }

            return (coorX, coorY);
        }

        private static ShotResult DetermineShotResult(IEnumerable<IEnumerable<(int X, int Y)>> ships, (int X, int Y) shotCoordinates, bool[,] takenShots)
        {
            var hitShip = ships.FirstOrDefault(ship => ship.Any(targetableSpot => targetableSpot == shotCoordinates));
            if (hitShip == null)
            {
                return ShotResult.Miss;
            }
            return HitOrSunk(hitShip, takenShots);
        }

        private static ShotResult HitOrSunk(IEnumerable<(int X, int Y)> ship, bool[,] takenShots)
        {
            return ship.All(coor => takenShots[coor.X, coor.Y]) ? ShotResult.Sunk : ShotResult.Hit;
        }
    }
}
