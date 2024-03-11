using Battleship.Models;

namespace Battleship.Services
{
    public interface ISetUpService
    {
        IEnumerable<IEnumerable<ShipPosition>> GenerateGameSetup();
    }
}
