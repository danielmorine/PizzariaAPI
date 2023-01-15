using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler;

public class IngredientCreateCommandHandler : IRequestHandler<IngredientCreateCommand, bool>
{
    private readonly IIngredientRepository _repository;

    public IngredientCreateCommandHandler(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IngredientCreateCommand request, CancellationToken cancellationToken)
    {
        Ingredient ingredient = new(Guid.NewGuid(), request.Name, DateTimeOffset.UtcNow);

        if (ingredient == null)
            throw new ApplicationException("Error creating entity");

        await _repository.AddAsync(ingredient);
        return true;
    }
}
