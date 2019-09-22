using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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
            Exception err = null;
            User user = null;
            var result = await _userEntryService.GetUserEntry(id);
            result.Subscribe((res) =>
            {
                user = res;
                Console.WriteLine(user);
            },
            (error) =>
            {
                err = error;
                Console.WriteLine(error);
            }, () => { });
            if (user == null)
            {
                BadRequest(err.Message);
            }
            return Ok(user);
        }

        [HttpGet("{id}/history")]
        [ProducesResponseType(typeof(UserHistory), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a Users previous season data from the specified id if one exists.")]
        public async Task<IActionResult> GetSeasonHistory(int id)
        {
            UserHistory seasonHistory = null;
            string errorMessage = string.Empty;
            var result = await _userEntryService.GetUserSeasonHistory(id);
                result.Subscribe(res => { seasonHistory = res; },
                (error) => { errorMessage = error.Message; },
                () => { });

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(seasonHistory);
        }

        [HttpGet("{id}/game-week/{eventId}/picks")]
        [ProducesResponseType(typeof(UserEventPicks), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a the team selections made by the user for a given game week.")]
        public async Task<IActionResult> GetPicksForEvent(int id, int eventId)
        {
            UserEventPicks picks = null;
            string errorMessage = string.Empty;
            var result = await _userEntryService.GetUserPlayerPicksForEvent(id, eventId);
            result.Subscribe(res => picks = res,
                error => errorMessage = error.Message,
                () => { });

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(picks);
        }

        [HttpGet("{id}/team")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the users current fantasy team, as well as any transfers made, and chips.")]
        public async Task<IActionResult> GetUserTeam(int id)
        {
            UserTeam team = null;
            string errorMessage = string.Empty;
            var result = await _userEntryService.GetUserTeam(id);
            result.Subscribe(res => team = res,
                error => errorMessage = error.Message,
                () => { });
           

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(team);
        }

        [HttpGet("{id}/transfers")]
        [ProducesResponseType(typeof(List<UserTransfer>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the transfer history for a given users fantasy team.")]
        public async Task<IActionResult> GetTransfers(int id)
        {
            (List<UserTransfer> transfers, string errorMessage) = await GetUserTransfers(id);

            if (transfers == null)
            {
                return BadRequest(errorMessage);
            }

            return Ok(transfers);
        }

        // Endpoint not working, disabled for now.
        // [HttpGet("{id}/transfers/{gameweek}")]
        [ProducesResponseType(typeof(List<UserTransfer>), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the transfer history for a given users fantasy team.")]
        public async Task<IActionResult> GetTransfersForGameweek(int id, int gameweek)
        {
            (List<UserTransfer> transfers, string errorMessage) = await GetUserTransfers(id, gameweek);

            if (transfers == null)
            {
                return BadRequest(errorMessage);
            }

            return Ok(transfers);
        }

        [HttpGet("{id}/cup")]
        // [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [Description("Returns the current seasons cup history for a given user.")]
        public IActionResult GetCups(int id)
        {
            throw new NotImplementedException("Endpoint not found, so cannot implement this yet!");
        }

        [HttpGet("watchlist")]
        [ProducesResponseType(typeof(UserPlayerWatchlist), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Description("Returns your player watchlist. You must be logged in to retrieve the data from this endpoint.")]
        public async Task<IActionResult> GetWatchlist()
        {
            UserPlayerWatchlist watchlist = null;
            string errorMessage = string.Empty;
            var result = await _userEntryService.GetUserWatchlist();
            result.Subscribe(res => watchlist = res,
                error => errorMessage = error.Message,
                () => { });

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(watchlist);
        }

        private async Task<(List<UserTransfer> transfers, string errorMessage)> GetUserTransfers(int id, int? gameweek = null)
        {
            List<UserTransfer> transfers = null;
            string errorMessage = string.Empty;

            var result = await _userEntryService.GetUserTransfers(id, gameweek);
            result.Subscribe(res => transfers = res,
                error => errorMessage = error.Message,
                () => { });

            return (transfers, errorMessage);
        }
    }
}