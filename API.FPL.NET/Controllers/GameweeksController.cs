using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models;
using FPL.NET.Models.Gameweeks;
using FPL.NET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/gameweek")]
    [Produces("application/json")]
    [ApiController]
    public class GameweeksController : ControllerBase
    {
        private readonly GameweekService _gameweekService;

        public GameweeksController(GameweekService service)
        {
            _gameweekService = service;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<Gameweek>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a list of gameweek data.")]
        public async Task<IActionResult> GetGameweeksAsync()
        {
            try
            {
                List<Gameweek> gameweeks = await _gameweekService.GetGameweeks();
                return Ok(gameweeks);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Gameweek>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a particular gameweek data.")]
        public async Task<IActionResult> GetGameweekAsync(int id)
        {
            try
            {
                Gameweek gameweek = await _gameweekService.GetGameweek(id);
                return Ok(gameweek);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}/live")]
        [ProducesResponseType(typeof(GameweekLiveDataMapping), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a particular gameweek data.")]
        public async Task<IActionResult> GetGameweekLivePlayerPerformanceDataAsync(int id)
        {
            try
            {
                GameweekLiveDataMapping liveData = await _gameweekService.GetGameweekLivePlayerPerformances(id);
                return Ok(liveData);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}