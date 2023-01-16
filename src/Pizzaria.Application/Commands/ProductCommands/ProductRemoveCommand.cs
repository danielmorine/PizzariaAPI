using MediatR;

namespace Pizzaria.Application.Commands.ProductCommands
{
    public class ProductRemoveCommand : IRequest<bool>
    {
        public Guid Id { get; private set; }

        public ProductRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
