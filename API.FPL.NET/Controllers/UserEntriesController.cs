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
        public IActionResult Get(int id)
        {
            Exception err = null;
            User user = null;
            _userEntryService.GetUserEntry(id).Result.Subscribe((result) =>
            {
                user = result;
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
//                return NotFound("User not found or some error occurred");
            }
            return Ok(user);
        }

        [HttpGet("{id}/history")]
        [ProducesResponseType(typeof(UserHistory), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a Users previous season data from the specified id if one exists.")]
        public IActionResult GetSeasonHistory(int id)
        {
            UserHistory seasonHistory = null;
            string err = null;
            _userEntryService.GetUserSeasonHistory(id).Result.Subscribe(result => { seasonHistory = result; },
                (error) => { err = error.Message; },
                () => { });

            return Ok(seasonHistory);
        }

        [HttpGet("{id}/game-week/{eventId}/picks")]
        [ProducesResponseType(typeof(UserEventPicks), 200)]
        [ProducesResponseType(400)]
        [Description("Returns a the team selections made by the user for a given game week.")]
        public IActionResult GetPicksForEvent(int id, int eventId)
        {
            UserEventPicks picks = null;
            string errorMessage = string.Empty;
            _userEntryService.GetUserPlayerPicksForEvent(id, eventId).Result.Subscribe(res => picks = res,
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
        public IActionResult GetUserTeam(int id)
        {
            UserTeam team = null;
            string errorMessage = string.Empty;
            _userEntryService.GetUserTeam(id).Result.Subscribe(res => team = res,
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
        public IActionResult GetTransfers(int id)
        {
            (List<UserTransfer> transfers, string errorMessage) = GetUserTransfers(id);

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
        public IActionResult GetTransfersForGameweek(int id, int gameweek)
        {
            (List<UserTransfer> transfers, string errorMessage) = GetUserTransfers(id, gameweek);

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

        private (List<UserTransfer> transfers, string errorMessage) GetUserTransfers(int id, int? gameweek = null)
        {
            List<UserTransfer> transfers = null;
            string errorMessage = string.Empty;

            _userEntryService.GetUserTransfers(id, null).Result.Subscribe(res => transfers = res,
                error => errorMessage = error.Message,
                () => { });

            return (transfers, errorMessage);
        }
    }
}