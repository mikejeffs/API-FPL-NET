using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models;
using FPL.NET.Models.League;
using FPL.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [ApiController]
    [Route("api/v0/fixture")]
    [Produces("application/json")]
    public sealed class FixturesController : ControllerBase
    {
        private readonly FixtureService _fixtureService;

        public FixturesController(FixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(List<Fixture>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns all fixtures played in the current season.")]
        public async Task<IActionResult> GetFixturesAsync()
        {
            try
            {
                List<Fixture> fixtures = await _fixtureService.GetFixtures();
                return Ok(fixtures);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("id")]
        [ProducesResponseType(typeof(List<Fixture>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a fixture.")]
        public async Task<IActionResult> GetFixtureAsync(int id)
        {
            try
            {
                List<Fixture> fixtures = await _fixtureService.GetFixtures();
                return Ok(fixtures);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("fixtureId")]
        [ProducesResponseType(typeof(FixtureStats), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a list of fixture stats for a given fixture based on the stat identifier provided." +
                     "\n Stat Identifiers: 'goal_scorers'; 'assists'; 'own_goals'; 'penalties_saved'; 'penalties_missed'; 'yellow_cards'; 'red_cards'; 'saves'; 'bonus'; 'bps';")]
        public async Task<IActionResult> GetPreciseStatsForFixtureAsync(int fixtureId, [FromQuery] string statIdentifier)
        {
            try
            {
                FixtureStats stats = await _fixtureService.GetPreciseStatsForFixture(fixtureId, statIdentifier);
                return Ok(stats);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}