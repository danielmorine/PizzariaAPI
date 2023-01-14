using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Queries.IngredientQueries
{
    public class GetAllIngredientQuery : IRequest<IEnumerable<Ingredient>>
    { }
}
