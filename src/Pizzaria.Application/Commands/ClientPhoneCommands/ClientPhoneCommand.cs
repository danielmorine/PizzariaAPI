using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Commands.ClientPhoneCommands
{
    public class ClientPhoneCommand : IRequest<ClientPhone>
    {
        public string RegionNumber { get; private set; }
        public string Number { get; private set; }
    }
}
