using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDTO>> GetAllAsync();
        Task<IngredientDTO> GetByIdAsync(Guid id);
        Task AddAsync(IngredientDTO dto);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(IngredientDTO dto);
    }
}
