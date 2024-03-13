using Battleship.Models;
using Battleship.Services;
using Xunit;

namespace UnitTests.Services
{
    public class SetUpServiceTests
    {
        private readonly SetUpService _sut;

        public SetUpServiceTests()
        {
            _sut = new SetUpService();
        }

        [Fact]
        public void GenerateGameSetup_ShouldReturnNestedEnumerableOfShipPosition()
        {
            // Act
            var result = _sut.GenerateGameSetup();

            // Assert
            Assert.IsAssignableFrom<List<List<Ship>>>(result);
        }
    }
}
