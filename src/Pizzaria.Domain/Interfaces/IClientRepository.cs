using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task AddAsync(Client client);
        Task<IEnumerable<Client?>> GetAllAsync();
        Task<Client?> GetAsync(Guid id);

        Task UpdateAsync(Client client);
    }
}
