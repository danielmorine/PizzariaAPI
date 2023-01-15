using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces;

public interface IClientPhoneRepository
{
    Task AddAsync(ClientPhone clientPhone);
    Task UpdateAsync(ClientPhone clientPhone);       
}
