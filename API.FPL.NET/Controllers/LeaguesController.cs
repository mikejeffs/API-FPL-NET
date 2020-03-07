using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models.League;
using FPL.NET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/league")]
    [Produces("application/json")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ClassicLeagueService _classicLeagueService;

        public LeaguesController(ClassicLeagueService classicLeagueService)
        {
            _classicLeagueService = classicLeagueService;
        }

        [HttpGet("classic/{id}/standings")]
        [ProducesResponseType(typeof(ClassicLeagueMapping), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a classic leagues current standings.")]
        public async Task<IActionResult> GetClassicLeagueStandings(int id)
        {
            try
            {
                ClassicLeagueMapping league = await _classicLeagueService.GetStandings(id);
                return Ok(league);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}