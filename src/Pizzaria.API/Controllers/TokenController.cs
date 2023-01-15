using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _service;

        public TokenController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            try
            {
                var result = await _service.AuthenticateAsync(user.Email, user.Password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(LoginDTO user)
        {
            try
            {
               await _service.RegisterUserAsync(user.Email, user.Password);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
    }
}
