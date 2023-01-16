using MediatR;

namespace Pizzaria.Application.Commands.ProductCommands;

public class ProductCommand : IRequest<bool>
{
    public string Name { get; set; }
}
