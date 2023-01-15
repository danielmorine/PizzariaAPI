using MediatR;
using Pizzaria.Application.Commands.ClientAddressCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ClientAddressHandler
{
    public class ClientAddressCreateCommandHandler : IRequestHandler<ClientAddressCreateCommand, ClientAddress>
    {
        private readonly IClientAddressRepository _repository;

        public ClientAddressCreateCommandHandler(IClientAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientAddress> Handle(ClientAddressCreateCommand request, CancellationToken cancellationToken)
        {
            var clientAddress = new ClientAddress(Guid.NewGuid(), DateTimeOffset.UtcNow,
                request.Address, request.Number, request.Complement, request.City,
                request.ZipCode);

            await _repository.AddAsync(clientAddress);
            return clientAddress;
        }
    }
}
