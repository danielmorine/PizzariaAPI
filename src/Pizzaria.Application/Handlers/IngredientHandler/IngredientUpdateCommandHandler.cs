using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler;

public class IngredientUpdateCommandHandler : IRequestHandler<IngredientUpdateCommand, bool>
{
    private readonly IIngredientRepository _repository;

    public IngredientUpdateCommandHandler(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IngredientUpdateCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _repository.GetByIdAsync(request.Id);

        if (ingredient is null)
        {
            return false;
        }            

        ingredient.Update(request.Name);

        await _repository.UpdateAsync(ingredient);
        return true;
    }
}
