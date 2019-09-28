using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetClassicLeagueStandings(int id)
        {
            ClassicLeagueMapping league = null;
            string errorMessage = string.Empty;
            var result = await _classicLeagueService.GetStandings(id);
            result.Subscribe(res => league = res,
                error => errorMessage = error.Message,
                () => { });

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(league);
        }
    }
}