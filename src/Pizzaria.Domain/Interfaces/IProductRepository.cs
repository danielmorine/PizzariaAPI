using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product?>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}
