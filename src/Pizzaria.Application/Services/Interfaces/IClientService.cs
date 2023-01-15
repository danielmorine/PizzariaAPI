using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Services.Interfaces;

public interface IClientService
{
    Task AddAsync(ClientDTO dto);
}
