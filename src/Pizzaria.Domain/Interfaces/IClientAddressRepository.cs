using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces;

public interface IClientAddressRepository
{
    Task AddAsync(ClientAddress clientAddress);
    Task UpdateAsync(ClientAddress clientAddress);       
}
