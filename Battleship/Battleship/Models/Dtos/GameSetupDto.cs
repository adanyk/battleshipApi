namespace Battleship.Models.Dtos
{
    public class GameSetupDto
    {
        public IEnumerable<IEnumerable<ShipDto>>? ShipsPositions { get; set; }
        public IEnumerable<ShotDto>? Shots { get; set; }
    }
}
