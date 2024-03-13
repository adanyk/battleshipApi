namespace Battleship.Models.Dtos
{
    public class GameSetupDto
    {
        public IEnumerable<IEnumerable<ShipDto>>? Ships { get; set; }
        public IEnumerable<ShotDto>? Shots { get; set; }
    }
}
