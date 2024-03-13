using Battleship.Models.Dtos;
using Battleship.Models;

namespace Battleship.Services
{
    public interface IModelMappingService
    {
        IEnumerable<IEnumerable<ShipDto>> MapToShipsPositionsDto(IEnumerable<IEnumerable<Ship>> ships);
        IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots);
    }

    public class ModelMappingService : IModelMappingService
    {
        public IEnumerable<IEnumerable<ShipDto>> MapToShipsPositionsDto(IEnumerable<IEnumerable<Ship>> ships)
        {
            return ships.Select(row => row.Select(sp => new ShipDto
            {
                Width = sp.Orientation == Orientation.Horizontal ? $"{sp.Size * 10}%" : "10%",
                Height = sp.Orientation == Orientation.Vertical ? $"{sp.Size * 10}%" : "10%",
                Top = $"{sp.Coordinates.X * 10}%",
                Left = $"{sp.Coordinates.Y * 10}%"
            }));
        }

        public IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots)
        {
            return shots.Select(s => new ShotDto
            {
                CoorX = s.Coordinates.X,
                CoorY = s.Coordinates.Y,
                Result = s.Result.ToString().ToLower()
            });
        }
    }
}
