using Battleship.Models.Dtos;
using Battleship.Models;

namespace Battleship.Services
{
    public interface IModelMappingService
    {
        IEnumerable<IEnumerable<ShipDto>> MapToShipsDto(IEnumerable<IEnumerable<Ship>> ships);
        IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots);
    }

    public class ModelMappingService : IModelMappingService
    {
        public IEnumerable<IEnumerable<ShipDto>> MapToShipsDto(IEnumerable<IEnumerable<Ship>> ships)
        {
            return ships.Select(row => row.Select(ship => new ShipDto
            {
                Width = ship.Orientation == Orientation.Horizontal ? $"{ship.Size * 10}%" : "10%",
                Height = ship.Orientation == Orientation.Vertical ? $"{ship.Size * 10}%" : "10%",
                Top = $"{ship.Coordinates.X * 10}%",
                Left = $"{ship.Coordinates.Y * 10}%"
            }));
        }

        public IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots)
        {
            return shots.Select(shot => new ShotDto
            {
                CoorX = shot.Coordinates.X,
                CoorY = shot.Coordinates.Y,
                Result = shot.Result.ToString().ToLower()
            });
        }
    }
}
