using Battleship.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("start")]
        public IActionResult StartGame()
        {
            var setup = _gameService.GenerateGameSetup();
            return Ok(setup);
        }
    }
}
