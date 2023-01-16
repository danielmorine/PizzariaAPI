using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientsController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _ingredientService.GetAllAsync();
        return result.Success ? Ok(result.Payload) : BadRequest(result.MessageError);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _ingredientService.GetByIdAsync(id);
        return result.Success ? Ok(result.Payload) : BadRequest(result.MessageError);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] IngredientDTO dto)
    {
        var result = await _ingredientService.AddAsync(dto);

        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] IngredientDTO dto)
    {
        var result = await _ingredientService.UpdateAsync(dto);

        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _ingredientService.DeleteAsync(id);
        return result.Success ? NoContent() : BadRequest(result.MessageError);
    }
}
