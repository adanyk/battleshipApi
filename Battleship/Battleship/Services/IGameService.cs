using Battleship.Models;

namespace Battleship.Services
{
    public interface IGameService
    {
        List<List<ShipPosition>> GenerateGameSetup();
    }
}
