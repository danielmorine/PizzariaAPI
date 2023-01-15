using MediatR;

namespace Pizzaria.Application.Commands.ClientAddressCommands
{
    public class ClientAddressRemoveCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
