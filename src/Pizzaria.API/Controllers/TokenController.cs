using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.API.Controllers;

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
        var result = await _service.AuthenticateAsync(user.Email, user.Password);        
        return result.Success ? Ok(result.Payload) : BadRequest(result.MessageError);       
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(LoginDTO user)
    {
        var result = await _service.RegisterUserAsync(user.Email, user.Password);
        return result.Success ? Ok() : BadRequest(result.MessageError);
    }
}
