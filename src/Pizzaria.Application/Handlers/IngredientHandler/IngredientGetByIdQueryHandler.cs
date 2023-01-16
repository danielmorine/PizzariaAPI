using MediatR;
using Pizzaria.Application.Queries.IngredientQueries;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler;

public class IngredientGetByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, Ingredient>
{
    private readonly IIngredientRepository _repository;

    public IngredientGetByIdQueryHandler(IIngredientRepository repository)
    {
        _repository = repository;
    }
    public async Task<Ingredient> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
