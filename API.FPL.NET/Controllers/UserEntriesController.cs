using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPL.NET.Models;
using FPL.NET.Models.User;
using FPL.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/user-entry")]
    [ApiController]
    public class UserEntriesController : ControllerBase
    {

        private readonly UserEntryService _userEntryService;

        public UserEntriesController(UserEntryService service)
        {
            _userEntryService = service;
        }

     
        [HttpGet("{id}")]
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
        public IActionResult GetTransfers(int id)
        {
            throw new NotImplementedException("Endpoint not found, so cannot implement this yet!");
        }

        [HttpGet("{id}/cup")]
        public IActionResult GetCups(int id)
        {
            throw new NotImplementedException("Endpoint not found, so cannot implement this yet!");
        }
    }
}