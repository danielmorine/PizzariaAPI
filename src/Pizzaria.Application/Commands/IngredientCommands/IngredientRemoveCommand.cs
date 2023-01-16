using MediatR;

namespace Pizzaria.Application.Commands.IngredientCommands;

public class IngredientRemoveCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
