using Battleship.Models;

namespace Battleship.Services
{
    public interface IGameplayService
    {
        List<Shot> GenerateShots(List<List<Ship>> ships);
    }
}
