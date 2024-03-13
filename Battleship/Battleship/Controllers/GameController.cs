using Battleship.Models.Dtos;
using Battleship.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController(ISetUpService setUpService, IGameplayService gameplayService, IModelMappingService modelMappingService) : ControllerBase
    {
        [HttpGet("start")]
        public IActionResult GetGameSetup()
        {
            var ships = setUpService.GenerateGameSetup();
            var shots = gameplayService.GenerateShots(ships);

            var shipsDto = modelMappingService.MapToShipsDto(ships);
            var shotsDto = modelMappingService.MapToShotsDto(shots);

            var gameSetup = new GameSetupDto
            {
                Ships = shipsDto,
                Shots = shotsDto
            };

            return Ok(gameSetup);
        }
    }
}
