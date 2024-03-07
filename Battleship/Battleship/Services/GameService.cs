using Battleship.Models;

namespace Battleship.Services
{
    public class GameService : IGameService
    {
        public List<List<ShipPosition>> GenerateGameSetup()
        {
            // Mimic the mockGetShipsPositions data structure
            return
            [
                [
                    new ShipPosition { Width = "40%", Height = "10%", Top = "0%", Left = "10%"},
                    new ShipPosition { Width = "10%", Height = "30%", Top = "0%", Left = "0%"}
                ],
                [
                    new ShipPosition { Width = "30%", Height = "10%", Top = "90%", Left = "0%"},
                    new ShipPosition { Width = "30%", Height = "10%", Top = "90%", Left = "70%"},
                    new ShipPosition { Width = "30%", Height = "10%", Top = "80%", Left = "50%"}
                ]
            ];
        }
    }
}
