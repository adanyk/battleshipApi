using Battleship.Models;
using Battleship.Services;
using Xunit;

namespace UnitTests.Services
{
    public class GameplayServiceTests
    {
        private readonly GameplayService _sut;

        public GameplayServiceTests()
        {
            _sut = new GameplayService();
        }

        [Fact]
        public void GenerateShots_ShouldReturnListOfShot()
        {
            // Arrange
            var ships = new List<List<Ship>>
            {
                new()
                {
                    new Ship { Coordinates = (5, 3), Size = 5, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (2, 3), Size = 4, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (6, 6), Size = 3, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (6, 2), Size = 3, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (8, 5), Size = 2, Orientation = Orientation.Horizontal }
                },
                new()
                {
                    new Ship { Coordinates = (4, 4), Size = 5, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (1, 2), Size = 4, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (3, 0), Size = 3, Orientation = Orientation.Vertical },
                    new Ship { Coordinates = (2, 3), Size = 3, Orientation = Orientation.Horizontal },
                    new Ship { Coordinates = (5, 5), Size = 2, Orientation = Orientation.Vertical }
                }
            };

            // Act
            var result = _sut.GenerateShots(ships);

            // Assert
            Assert.IsAssignableFrom<List<Shot>>(result);
        }
    }
}
