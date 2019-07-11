using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPL.NET.Models;
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
    }
}