using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPL.NET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/game-week")]
    [Produces("application/json")]
    [ApiController]
    public class GameweeksController : ControllerBase
    {
        private readonly GameweekService _gameweekService;

        public GameweeksController(GameweekService service)
        {
            _gameweekService = service;
        }

    }
}