using AutoMapper;
using InventoryTask.Authentication.Interfaces;
using InventoryTask.Dtos.User;
using InventoryTask.Entities;
using InventoryTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser createUser)
        {
            var result = await _authenticationService.RegisterAsync(createUser);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var result = await _authenticationService.LoginAsync(loginUser);
            if (!result.Success)
                return Unauthorized(result);
            return Ok(result);
        }
    }
}
