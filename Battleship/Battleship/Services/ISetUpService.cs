using Battleship.Models;

namespace Battleship.Services
{
    public interface ISetUpService
    {
        List<List<Ship>> GenerateGameSetup();
    }
}
