using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces
{
    public interface IProductIngredientRepository
    {
        Task AddAsync(ProductIngredient productIngredient);
        Task DeleteAsync(ProductIngredient productIngredient);
    }
}
