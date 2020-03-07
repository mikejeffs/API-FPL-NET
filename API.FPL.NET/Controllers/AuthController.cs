using System.ComponentModel;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Models.DataTransferObjects;
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
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [Description("Authenticates a logged in user to access certain endpoints.")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Password))
                {
                    return BadRequest("no_email_or_password_provided");
                }

                string result = await _authService.Login(login);
                return Ok(result);
            }
            catch (FplException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}