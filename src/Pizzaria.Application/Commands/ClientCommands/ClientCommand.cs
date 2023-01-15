using MediatR;

namespace Pizzaria.Application.Commands.ClientCommands
{
    public class ClientCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
