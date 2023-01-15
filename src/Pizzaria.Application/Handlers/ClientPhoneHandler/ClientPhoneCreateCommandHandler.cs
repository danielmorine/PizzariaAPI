using MediatR;
using Pizzaria.Application.Commands.ClientPhoneCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ClientPhoneHandler;

public class ClientPhoneCreateCommandHandler : IRequestHandler<ClientPhoneCreateCommand, ClientPhone>
{
    private readonly IClientPhoneRepository _repository;

    public ClientPhoneCreateCommandHandler(IClientPhoneRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClientPhone> Handle(ClientPhoneCreateCommand request, CancellationToken cancellationToken)
    {
        var clientPhone = new ClientPhone(Guid.NewGuid(), DateTimeOffset.UtcNow,
            request.RegionNumber, request.Number);

        await _repository.AddAsync(clientPhone);
        return clientPhone;
    }
}
