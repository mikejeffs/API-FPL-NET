using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models.Cup;
using FPL.NET.Models.User;
using FPL.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/user-entry")]
    [Produces("application/json")]
    [ApiController]
    public class UserEntriesController : ControllerBase
    {
        private readonly UserEntryService _userEntryService;

        public UserEntriesController(UserEntryService service)
        {
            _userEntryService = service;
        }

     
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a User from the specified id if one exists.")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                User user = await _userEntryService.GetUserEntry(id);
                return Ok(user);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/season-history")]
        [ProducesResponseType(typeof(UserHistory), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a Users previous season data from the specified id if one exists.")]
        public async Task<IActionResult> GetSeasonHistory(int id)
        {
            try
            {
                UserHistory result = await _userEntryService.GetUserSeasonHistory(id);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/game-week/{eventId}/picks")]
        [ProducesResponseType(typeof(UserEventPicks), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a the team selections made by the user for a given game week.")]
        public async Task<IActionResult> GetPicksForEvent(int id, int eventId)
        {
            try
            {
                UserEventPicks result = await _userEntryService.GetUserPlayerPicksForEvent(id, eventId);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/team")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the users current fantasy team, as well as any transfers made, and chips.")]
        public async Task<IActionResult> GetUserTeam(int id)
        {
            try
            {
                UserTeam result = await _userEntryService.GetUserTeam(id);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/transfers")]
        [ProducesResponseType(typeof(List<UserTransfer>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the transfer history for a given users fantasy team.")]
        public async Task<IActionResult> GetTransfers(int id)
        {
            try
            {
                List<UserTransfer> result = await _userEntryService.GetUserTransfers(id);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
            
            // (List<UserTransfer> transfers, string errorMessage) = await GetUserTransfers(id);
            //
            // if (transfers == null)
            // {
            //     return BadRequest(errorMessage);
            // }
            //
            // return Ok(transfers);
        }

        // Endpoint not working, disabled for now.
        // [HttpGet("{id}/transfers/{gameweek}")]
        // [ProducesResponseType(typeof(List<UserTransfer>), 200)]
        // [ProducesResponseType(400)]
        // [Description("Returns the transfer history for a given users fantasy team.")]
        // public async Task<IActionResult> GetTransfersForGameweek(int id, int gameweek)
        // {
        //     try
        //     {
        //         List<UserTransfer> result = await _userEntryService.GetUserTransfers(id, gameweek);
        //         return Ok(result);
        //     }
        //     catch (FplException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        [HttpGet("{id}/cup")]
        [ProducesResponseType(typeof(Cup), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the current seasons cup history for a given user.")]
        public async Task<IActionResult> GetUserCupStatusAsync(int id)
        {
			try
			{
				Cup cup = await _userEntryService.GetUserCupStatus(id); // TODO: Returns null for cup status and cup matches properties.
				return Ok(cup);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        [HttpGet("watchlist")]
        [ProducesResponseType(typeof(UserPlayerWatchlist), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns your player watchlist. You must be logged in to retrieve the data from this endpoint.")]
        public async Task<IActionResult> GetWatchlist()
        {
            try
            {
                UserPlayerWatchlist result = await _userEntryService.GetUserWatchlist();
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/gameweek/{gameweek}/picks")]
        [ProducesResponseType(typeof(UserPlayerPicks), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns a list of player picks made by a user for a given gameweek.")]
        public async Task<IActionResult> GetPlayerPicksForGameweekAsync(int id, int gameweek)
        {
            try
            {
                UserPlayerPicks result = await _userEntryService.GetPlayerPicksForGameweek(id, gameweek);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/gameweek/{gameweek}/automatic-substitutions")]
        [ProducesResponseType(typeof(UserPlayerPicks), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns a list of any automatic substitutions made in a given gameweek.")]
        public async Task<IActionResult> GetAutomaticSubstitutionsForGameweekAsync(int id, int gameweek)
        {
            try
            {
                UserAutomaticSubstitutions result = await _userEntryService.GetAutomaticSubstitutionsForGameweek(id, gameweek);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/gameweek/{gameweek}/active-chip")]
        [ProducesResponseType(typeof(UserActiveChip), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns the active chip for a users team for a given gameweek.")]
        public async Task<IActionResult> GetActiveChipForGameweekAsync(int id, int gameweek)
        {
            try
            {
                UserActiveChip result = await _userEntryService.GetActiveChipForGameweek(id, gameweek);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}/gameweek-history")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns the history (points, etc.) of each gameweek in the current season for the user.")]
        public async Task<IActionResult> GetGameweekHistory(int id)
        {
            try
            {
                UserGameweekHistory data = await _userEntryService.GetGameweekHistory(id);
                return Ok(data);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}