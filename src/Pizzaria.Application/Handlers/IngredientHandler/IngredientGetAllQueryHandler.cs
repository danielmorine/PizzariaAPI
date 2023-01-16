using MediatR;
using Pizzaria.Application.Queries.IngredientQueries;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.IngredientHandler;

public class IngredientGetAllQueryHandler : IRequestHandler<GetAllIngredientQuery, IEnumerable<Ingredient>>
{
    private readonly IIngredientRepository _repository;

    public IngredientGetAllQueryHandler(IIngredientRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Ingredient?>> Handle(GetAllIngredientQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
