using Battleship.Models.Dtos;
using Battleship.Models;

namespace Battleship.Services
{
    public interface IModelMappingService
    {
        IEnumerable<IEnumerable<ShipPositionDto>> MapToShipPositionsDto(IEnumerable<IEnumerable<ShipPosition>> shipPositions);
        IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots);
    }

    public class ModelMappingService : IModelMappingService
    {
        public IEnumerable<IEnumerable<ShipPositionDto>> MapToShipPositionsDto(IEnumerable<IEnumerable<ShipPosition>> shipPositions)
        {
            return shipPositions.Select(row => row.Select(sp => new ShipPositionDto
            {
                Width = sp.Orientation == Orientation.Horizontal ? $"{sp.Size * 10}%" : "10%",
                Height = sp.Orientation == Orientation.Vertical ? $"{sp.Size * 10}%" : "10%",
                Top = $"{sp.Coordinates.X * 10}%",
                Left = $"{sp.Coordinates.Y * 10}%"
            }));
        }

        public IEnumerable<ShotDto> MapToShotsDto(IEnumerable<Shot> shots)
        {
            throw new NotImplementedException();
        }
    }
}
