using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models.Fixtures;
using FPL.NET.Models.Players;
using FPL.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/player")]
    [Produces("application/json")]
    [ApiController]
    public sealed class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService) => _playerService = playerService;
        
        [HttpGet]
        [ProducesResponseType(typeof(List<Player>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a list of all players.")]
        public async Task<IActionResult> GetPlayersAsync()
        {
            try
            {
                List<Player> players = await _playerService.GetPlayers();
                return Ok(players);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}/summary")]
        [ProducesResponseType(typeof(PlayerSummaryFixtureMapping), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a players summary for a gameweek.")]
        public async Task<IActionResult> GetPlayerSummaryAsync(int id)
        {
            try
            {
                PlayerSummaryFixtureMapping playerSummaryFixture = await _playerService.GetPlayerFixtureSummary(id);
                return Ok(playerSummaryFixture);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}