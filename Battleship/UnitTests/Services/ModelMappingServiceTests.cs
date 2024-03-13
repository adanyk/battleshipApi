using Battleship.Models;
using Battleship.Models.Dtos;
using Battleship.Services;
using Xunit;

namespace UnitTests.Services
{
    public class ModelMappingServiceTests
    {
        private readonly ModelMappingService _sut;

        public ModelMappingServiceTests()
        {
            _sut = new ModelMappingService();
        }

        [Fact]
        public void MapToShipsPositionsDto_ShouldCorrectlyTransformShipsPositionsToDto()
        {
            // Arrange
            var ships = new List<List<Ship>>
            {
                new()
                {
                    new Ship { Coordinates = (0, 1), Size = 4, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (0, 0), Size = 3, Orientation = Orientation.Vertical }
                },
                new()
                {
                    new Ship { Coordinates = (9, 0), Size = 3, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (9, 7), Size = 3, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (8, 5), Size = 3, Orientation = Orientation.Horizontal }
                }
            };
            var expected = new List<List<ShipDto>>
            {
                new()
                {
                    new ShipDto { Width = "40%", Height = "10%", Top = "0%", Left = "10%" },
                    new ShipDto { Width = "10%", Height = "30%", Top = "0%", Left = "0%" }
                },
                new()
                {
                    new ShipDto { Width = "30%", Height = "10%", Top = "90%", Left = "0%" },
                    new ShipDto { Width = "30%", Height = "10%", Top = "90%", Left = "70%" },
                    new ShipDto { Width = "30%", Height = "10%", Top = "80%", Left = "50%" }
                }
            };

            // Act
            var result = _sut.MapToShipsPositionsDto(ships);

            // Assert
            var returnValue = Assert.IsAssignableFrom<IEnumerable<IEnumerable<ShipDto>>>(result);
            Assert.Equivalent(expected, returnValue);
        }

        [Fact]
        public void MapToShotsDto_ShouldCorrectlyTransformShotsToDto()
        {
            // Arrange
            var shots = new List<Shot>
            {
                new() { Coordinates =  (0, 0), Result = ShotResult.Miss }, new() { Coordinates =  (0, 1), Result = ShotResult.Hit },
                new() { Coordinates =  (1, 1), Result = ShotResult.Miss }, new() { Coordinates =  (0, 2), Result = ShotResult.Hit },
                new() { Coordinates =  (2, 2), Result = ShotResult.Miss }, new() { Coordinates =  (0, 3), Result = ShotResult.Sunk }
            };
            var expected = new List<ShotDto>
            {
                new() { CoorX = 0, CoorY = 0, Result = "miss" }, new() { CoorX = 0, CoorY = 1, Result = "hit" },
                new() { CoorX = 1, CoorY = 1, Result = "miss" }, new() { CoorX = 0, CoorY = 2, Result = "hit" },
                new() { CoorX = 2, CoorY = 2, Result = "miss" }, new() { CoorX = 0, CoorY = 3, Result = "sunk" }
            };

            // Act
            var result = _sut.MapToShotsDto(shots);

            // Assert
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ShotDto>>(result);
            Assert.Equivalent(expected, returnValue);
        }
    }
}
