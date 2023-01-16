using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Services.Interfaces;

public interface IIngredientService
{
    Task<IResponseResult<IEnumerable<IngredientDTO>>> GetAllAsync();
    Task<IResponseResult<IngredientDTO>> GetByIdAsync(Guid id);
    Task<ResponseResult> AddAsync(IngredientDTO dto);
    Task<ResponseResult> DeleteAsync(Guid id);
    Task<ResponseResult> UpdateAsync(IngredientDTO dto);
}
