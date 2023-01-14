using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler
{
    public class IngredientRemoveCommandHandler : IRequestHandler<IngredientRemoveCommand, bool>
    {
        private readonly IIngredientRepository _repository;

        public IngredientRemoveCommandHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IngredientRemoveCommand request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Id, request.Name, request.CreatedDate);
            await _repository.DeleteAsync(ingredient);

            return true;
        }
    }
}
