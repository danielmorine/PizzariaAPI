using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Payload) : BadRequest(result.MessageError);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Payload) : BadRequest(result.MessageError);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ProductDTO dto)
    {
        var result = await _service.AddAsync(dto);

        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] ProductDTO dto)
    {
        var result = await _service.UpdateAsync(dto);

        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }
}
