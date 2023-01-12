using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;

namespace Pizzaria.Infra.Data.Repositories
{
    public class ClientPhoneRepository : IClientPhoneRepository
    {
        private readonly ApplicationDbContext _context; 
     
        public ClientPhoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClientPhone clientPhone)
        {
            await _context.ClientPhones.AddAsync(clientPhone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClientPhone clientPhone)
        {
            _context.ClientPhones.Update(clientPhone);
            await _context.SaveChangesAsync();
        }
    }
}
