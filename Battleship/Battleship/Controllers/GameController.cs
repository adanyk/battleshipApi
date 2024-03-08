using Battleship.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ISetUpService _gameService;
        private readonly IModelMappingService _modelMappingService;

        public GameController(ISetUpService gameService, IModelMappingService modelMappingService)
        {
            _gameService = gameService;
            _modelMappingService = modelMappingService;
        }

        [HttpGet("start")]
        public IActionResult GetShipsPositions()
        {
            var shipsPositions = _gameService.GenerateGameSetup();
            var shipsPositionsDto = _modelMappingService.MapToShipPositionsDto(shipsPositions);
            return Ok(shipsPositionsDto);
        }
    }
}
