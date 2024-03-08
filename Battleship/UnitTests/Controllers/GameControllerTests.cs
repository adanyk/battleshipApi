using Battleship.Controllers;
using Battleship.Models;
using Battleship.Models.Dtos;
using Battleship.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests.Controllers
{
    public class GameControllerTests
    {
        private readonly Mock<ISetUpService> _setUpServiceMock;
        private readonly Mock<IModelMappingService> _modelMappingServiceMock;
        private readonly GameController _sut;

        public GameControllerTests()
        {
            _setUpServiceMock = new Mock<ISetUpService>();
            _modelMappingServiceMock = new Mock<IModelMappingService>();
            _sut = new GameController(_setUpServiceMock.Object, _modelMappingServiceMock.Object);
        }

        [Fact]
        public void GetShipsPositions_Should_ReturnOkResultWithShipPositions()
        {
            // Arrange
            var expected = new List<List<ShipPositionDto>>
            {
                new() { new ShipPositionDto(), new ShipPositionDto() },
                new() { new ShipPositionDto(), new ShipPositionDto() }
            };

            _modelMappingServiceMock.Setup(x => x.MapToShipPositionsDto(It.IsAny<IEnumerable<IEnumerable<ShipPosition>>>()))
                .Returns(expected);

            // Act
            var result = _sut.GetShipsPositions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<List<ShipPositionDto>>>(okResult.Value);
            Assert.Equal(expected, returnValue);
        }
    }
}