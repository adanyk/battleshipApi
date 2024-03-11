﻿using Battleship.Models.Dtos;
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
            var shipsPositions = setUpService.GenerateGameSetup();
            var shots = gameplayService.GenerateShots(shipsPositions);

            var shipsPositionsDto = modelMappingService.MapToShipsPositionsDto(shipsPositions);
            var shotsDto = modelMappingService.MapToShotsDto(shots);

            var gameSetup = new GameSetupDto
            {
                ShipsPositions = shipsPositionsDto,
                Shots = shotsDto
            };

            return Ok(gameSetup);
        }
    }
}
