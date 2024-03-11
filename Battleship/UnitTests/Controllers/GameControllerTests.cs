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
        private readonly Mock<IGameplayService> _gameplayService;
        private readonly Mock<IModelMappingService> _modelMappingServiceMock;
        private readonly GameController _sut;

        public GameControllerTests()
        {
            _setUpServiceMock = new Mock<ISetUpService>();
            _gameplayService = new Mock<IGameplayService>();
            _modelMappingServiceMock = new Mock<IModelMappingService>();
            _sut = new GameController(_setUpServiceMock.Object, _gameplayService.Object, _modelMappingServiceMock.Object);
        }

        [Fact]
        public void GetGameSetup_Should_ReturnOkResultWithGameSetup()
        {
            // Arrange
            var shipsPositions = new List<List<ShipPositionDto>>
            {
                new() { new ShipPositionDto(), new ShipPositionDto() },
                new() { new ShipPositionDto(), new ShipPositionDto() }
            };
            var shots = new List<ShotDto> { new(), new() };
            var expected = new GameSetupDto { ShipsPositions = shipsPositions, Shots = shots };

            _modelMappingServiceMock.Setup(x => x.MapToShipsPositionsDto(It.IsAny<IEnumerable<IEnumerable<ShipPosition>>>()))
                .Returns(shipsPositions);
            _modelMappingServiceMock.Setup(x => x.MapToShotsDto(It.IsAny<IEnumerable<Shot>>()))
                .Returns(shots);

            // Act
            var result = _sut.GetGameSetup();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<GameSetupDto>(okResult.Value);
            Assert.Equivalent(expected, returnValue);
        }
    }
}