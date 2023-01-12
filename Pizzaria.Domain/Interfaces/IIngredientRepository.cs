using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient?>> GetAllAsync();
        Task<Ingredient?> GetByIdAsync(Guid id);
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Ingredient ingredient);
    }
}
