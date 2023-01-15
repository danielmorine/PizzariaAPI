using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;

namespace Pizzaria.Infra.Data.Repositories;

public class ProductIngredientRepository : IProductIngredientRepository
{
    private readonly ApplicationDbContext _context;

    public ProductIngredientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(ProductIngredient productIngredient)
    {
        await _context.ProductIngredients.AddAsync(productIngredient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProductIngredient productIngredient)
    {
        _context.ProductIngredients.Remove(productIngredient);
        await _context.SaveChangesAsync();
    }
}
