using MediatR;

namespace Pizzaria.Application.Commands.IngredientCommands;

public class IngredientRemoveCommand : IRequest<bool>
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }

    public IngredientRemoveCommand(Guid id, string name, DateTimeOffset createdDate)
    {
        Id = id;
        Name = name;
        CreatedDate = createdDate;
    }
}
