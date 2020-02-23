using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FPL.NET.Models.DataTransferObjects;
using FPL.NET.Models.User;
using FPL.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.FPL.NET.Controllers
{
    [Route("api/v0/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService service)
        {
            _authService = service;
        }


        [HttpPost("login")]
        // [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [Description("Authenticates a logged in user to access certain endpoints.")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("no_email_or_password_provided");
            }

            Exception err = null;
            User user = null;
            var result = await _authService.Login(login);
            result.Subscribe((res) =>
                {
                    Console.WriteLine(res);
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
    }
}