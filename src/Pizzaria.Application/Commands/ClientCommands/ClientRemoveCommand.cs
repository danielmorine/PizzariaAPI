using MediatR;

namespace Pizzaria.Application.Commands.ClientCommands
{
    public class ClientRemoveCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
