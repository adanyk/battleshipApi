using Battleship.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController(ISetUpService setUpService, IModelMappingService modelMappingService) : ControllerBase
    {
        [HttpGet("start")]
        public IActionResult GetShipsPositions()
        {
            var shipsPositions = setUpService.GenerateGameSetup();
            var shipsPositionsDto = modelMappingService.MapToShipPositionsDto(shipsPositions);
            return Ok(shipsPositionsDto);
        }
    }
}
