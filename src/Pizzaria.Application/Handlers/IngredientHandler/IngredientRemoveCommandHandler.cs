using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler;

public class IngredientRemoveCommandHandler : IRequestHandler<IngredientRemoveCommand, bool>
{
    private readonly IIngredientRepository _repository;

    public IngredientRemoveCommandHandler(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IngredientRemoveCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _repository.GetByIdAsync(request.Id);

        if (ingredient is null)
        {
            return false;
        }

        await _repository.DeleteAsync(ingredient);

        return true;
    }
}
