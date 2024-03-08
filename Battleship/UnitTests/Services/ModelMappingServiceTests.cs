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
        public void MapToShipPositionsDto_ShouldCorrectlyTransformShipPositionToDto()
        {
            // Arrange
            var shipPositions = new List<List<ShipPosition>>
            {
                new()
                {
                    new ShipPosition { Coordinates = (0, 1), Size = 4, Orientation = Orientation.Horizontal },
                    new ShipPosition { Coordinates = (0, 0), Size = 3, Orientation = Orientation.Vertical }
                },
                new()
                {
                    new ShipPosition { Coordinates = (9, 0), Size = 3, Orientation = Orientation.Horizontal },
                    new ShipPosition { Coordinates = (9, 7), Size = 3, Orientation = Orientation.Horizontal },
                    new ShipPosition { Coordinates = (8, 5), Size = 3, Orientation = Orientation.Horizontal }
                }
            };
            var expected = new List<List<ShipPositionDto>>
            {
                new()
                {
                    new ShipPositionDto { Width = "40%", Height = "10%", Top = "0%", Left = "10%" },
                    new ShipPositionDto { Width = "10%", Height = "30%", Top = "0%", Left = "0%" }
                },
                new()
                {
                    new ShipPositionDto { Width = "30%", Height = "10%", Top = "90%", Left = "0%" },
                    new ShipPositionDto { Width = "30%", Height = "10%", Top = "90%", Left = "70%" },
                    new ShipPositionDto { Width = "30%", Height = "10%", Top = "80%", Left = "50%" }
                }
            };

            // Act
            var result = _sut.MapToShipPositionsDto(shipPositions);

            // Assert
            var returnValue = Assert.IsAssignableFrom<IEnumerable<IEnumerable<ShipPositionDto>>>(result);
            Assert.Equivalent(expected, returnValue);
        }
    }
}
