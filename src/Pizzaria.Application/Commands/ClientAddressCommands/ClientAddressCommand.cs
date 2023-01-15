using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Commands.ClientAddressCommands;

public class ClientAddressCommand : IRequest<ClientAddress>
{
    public string Address { get; private set; }
    public int Number { get; private set; }
    public string Complement { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
}
