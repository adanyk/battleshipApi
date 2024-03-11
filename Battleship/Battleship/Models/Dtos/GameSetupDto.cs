namespace Battleship.Models.Dtos
{
    public class GameSetupDto
    {
        public IEnumerable<IEnumerable<ShipPositionDto>>? ShipsPositions { get; set; }
        public IEnumerable<ShotDto>? Shots { get; set; }
    }
}
