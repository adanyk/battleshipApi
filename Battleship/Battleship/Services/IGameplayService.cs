using Battleship.Models;

namespace Battleship.Services
{
    public interface IGameplayService
    {
        IEnumerable<Shot> GenerateShots(IEnumerable<IEnumerable<ShipPosition>> shipsPositions);
    }
}
