using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;

namespace Pizzaria.Infra.Data.Repositories;

public class ClientAddressRepository : IClientAddressRepository
{
    private readonly ApplicationDbContext _context; 
 
    public ClientAddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ClientAddress clientAddress)
    {
        await _context.ClientAddresses.AddAsync(clientAddress);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ClientAddress clientAddress)
    {
        _context.ClientAddresses.Update(clientAddress);
        await _context.SaveChangesAsync();
    }
}
