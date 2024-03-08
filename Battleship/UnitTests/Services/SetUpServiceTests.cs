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
        public void GenerateGameSetup_Should_()
        {
            // Act
            var result = _sut.GenerateGameSetup();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<IEnumerable<ShipPosition>>>(result);
        }
    }
}
