using MediatR;
using Pizzaria.Application.Commands.ClientCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ClientHandlers;

public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, bool>
{
    private readonly IClientRepository _repository;

    public ClientCreateCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
    {
        var client = new Client(Guid.NewGuid(), request.Name, request.CreatedDate)
        {
            ClientPhoneId = request.ClientPhoneId,
            ClientAddressId = request.ClientAddressId
        };

        await _repository.AddAsync(client);
        return true;        
    }        
}
