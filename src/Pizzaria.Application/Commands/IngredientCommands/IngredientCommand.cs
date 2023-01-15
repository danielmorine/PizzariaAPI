using MediatR;

namespace Pizzaria.Application.Commands.IngredientCommands;

public abstract class IngredientCommand : IRequest<bool>
{
    public string Name { get; set; }
}
